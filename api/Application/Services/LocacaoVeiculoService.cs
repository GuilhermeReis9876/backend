using api.Domain.ViewModels;
using api.Application.Interfaces;
using AutoMapper;
using api.Domain.Interfaces;
using api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class LocacaoVeiculoService : ILocacaoVeiculoService
    {

        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ILocacaoVeiculoRepository _locacaoVeiculoRepository;
        private readonly IMapper _mapper;

        public LocacaoVeiculoService(IVeiculoRepository veiculoRepository,
            IClienteRepository clienteRepository,
            ILocacaoVeiculoRepository locacaoVeiculoRepository,
            IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _clienteRepository = clienteRepository;
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
            _mapper = mapper;
        }


        public async Task<LocacaoVeiculoViewModel> Agendar(LocacaoVeiculoViewModel locacaoVeiculoVM)
        {
            var cliente = await _clienteRepository.GetById(locacaoVeiculoVM.ClienteId);

            if (cliente == null)
                throw new Exception("Cliente não existe!");

            var veiculo = await _veiculoRepository.GetById(locacaoVeiculoVM.VeiculoId);

            if (veiculo == null)
                throw new Exception("Veículo não existe!");

            if (locacaoVeiculoVM.DataLocacao > locacaoVeiculoVM.DataDevolucao) throw new Exception("Data de locação não pode ser maior que devolução!");

            var locacoesDesteVeiculo = _locacaoVeiculoRepository.GetAll().Result.Where(x => x.VeiculoId == veiculo.Id).ToList();

            var diasParaAlugar = (locacaoVeiculoVM.DataDevolucao - locacaoVeiculoVM.DataLocacao).Days;

            locacaoVeiculoVM.LocacoesConflitantes = new HashSet<string>();

            if (diasParaAlugar == 0)
            {
                var locacoesDoDia = locacoesDesteVeiculo.Where(x => locacaoVeiculoVM.DataLocacao == x.DataLocacao.Date || locacaoVeiculoVM.DataLocacao.Date == x.DataDevolucao.Date).ToList();
                if(locacoesDoDia.Count == 0)
                {
                    locacaoVeiculoVM.TotalHoras = (int)(locacaoVeiculoVM.DataDevolucao - locacaoVeiculoVM.DataLocacao).TotalHours;
                    locacaoVeiculoVM.ValorLocacao = veiculo.ValorHora * locacaoVeiculoVM.TotalHoras;
                    locacaoVeiculoVM.Status = EnumStatusLocacao.Pendente;

                    try
                    {
                        await _locacaoVeiculoRepository.Save(_mapper.Map<LocacaoVeiculo>(locacaoVeiculoVM));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    foreach(var loc in locacoesDoDia)
                    {
                        locacaoVeiculoVM.LocacoesConflitantes.Add(loc.DataLocacao.ToString("dd/MM/yyyy") + "- até: " + loc.DataDevolucao.ToString("dd/MM/yyyy"));
                    }
                   
                }

                return locacaoVeiculoVM;
            }
                

            var diaLocado = locacaoVeiculoVM.DataLocacao;

            locacaoVeiculoVM.LocacoesConflitantes = new HashSet<string>();

            for (var dias = 0; dias < diasParaAlugar; dias++)
            {
                var locacaoParaODia = locacoesDesteVeiculo.Where(x => diaLocado >= x.DataLocacao && diaLocado <= x.DataDevolucao).SingleOrDefault();
                if (locacaoParaODia == null)
                    diaLocado = diaLocado.AddDays(1);
                else
                    locacaoVeiculoVM.LocacoesConflitantes.Add(locacaoParaODia.DataLocacao.ToString("dd/MM/yyyy") + "- até: " + locacaoParaODia.DataDevolucao.ToString("dd/MM/yyyy"));
            }

            if (locacaoVeiculoVM.LocacoesConflitantes.Count > 0)
                return locacaoVeiculoVM;


            locacaoVeiculoVM.TotalHoras = (int)(locacaoVeiculoVM.DataDevolucao - locacaoVeiculoVM.DataLocacao).TotalHours;
            locacaoVeiculoVM.ValorLocacao = veiculo.ValorHora * locacaoVeiculoVM.TotalHoras;

            try
            {
                await _locacaoVeiculoRepository.Save(_mapper.Map<LocacaoVeiculo>(locacaoVeiculoVM));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return locacaoVeiculoVM;

        }

        public async Task<SimulacaoViewModel> Simular(SimulacaoViewModel simulacaoVM)
        {
            var veiculo = await _veiculoRepository.GetById(simulacaoVM.VeiculoId);

            if (veiculo == null)
                throw new Exception("Veículo não existe!");


            simulacaoVM.TotalHoras = (int)(simulacaoVM.Saida - simulacaoVM.Entrada).TotalHours;

            simulacaoVM.ValorSimulado = veiculo.ValorHora * simulacaoVM.TotalHoras;

            return simulacaoVM;

        }
    }


}



