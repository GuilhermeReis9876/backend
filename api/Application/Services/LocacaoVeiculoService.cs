using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly IUtilService _utilService;

        public LocacaoVeiculoService(IVeiculoRepository veiculoRepository,
            IClienteRepository clienteRepository,
            ILocacaoVeiculoRepository locacaoVeiculoRepository,
            IMapper mapper,
            IUtilService utilService)
        {
            _veiculoRepository = veiculoRepository;
            _clienteRepository = clienteRepository;
            _locacaoVeiculoRepository = locacaoVeiculoRepository;
            _mapper = mapper;
            _utilService = utilService;
        }


        public async Task<LocacaoVeiculoViewModel> Agendar(LocacaoVeiculoViewModel locacaoVeiculoVM, string token)
        {
            var clienteId = await _utilService.GetUserByToken(token);

            // var cliente = await _clienteRepository.GetById(locacaoVeiculoVM.ClienteId);

            if (clienteId == null)
                throw new Exception("Cliente não existe!");

            var veiculo = await _veiculoRepository.GetById(locacaoVeiculoVM.VeiculoId);

            if (veiculo == null)
                throw new Exception("Veículo não existe!");

            if (locacaoVeiculoVM.DataLocacao > locacaoVeiculoVM.DataDevolucao) throw new Exception("Data de locação não pode ser maior que devolução!");

            var locacoesDesteVeiculo = _locacaoVeiculoRepository.GetAll().Result.Where(x => x.VeiculoId == veiculo.Id).ToList();

            locacaoVeiculoVM.LocacoesConflitantes = new HashSet<string>();

            var diaLocacao = locacaoVeiculoVM.DataLocacao;
            var diaDevolucao = locacaoVeiculoVM.DataDevolucao;

            locacaoVeiculoVM.LocacoesConflitantes = new HashSet<string>();

            double tempoExtraLiberacao = 3; // checkin + atraso do locatário anterior

            var locacoesConflitantes = locacoesDesteVeiculo.Where(x => (diaLocacao <= x.DataDevolucao.AddHours(tempoExtraLiberacao)) && (diaDevolucao.AddHours(tempoExtraLiberacao) >= x.DataLocacao)).ToList();

            if (locacoesConflitantes.Count > 0)
            {
                foreach (var loc in locacoesConflitantes)
                    locacaoVeiculoVM.LocacoesConflitantes.Add(loc.DataLocacao.ToString("G", CultureInfo.InvariantCulture) + " até: " + loc.DataDevolucao.AddHours(tempoExtraLiberacao).ToString("G", CultureInfo.InvariantCulture));
            }


            if (locacaoVeiculoVM.LocacoesConflitantes.Count > 0)
            {
                locacaoVeiculoVM.Error = "Carro já locado para a data escolhida!";
                return locacaoVeiculoVM;
            }

            locacaoVeiculoVM.ClienteId = clienteId.Id;
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

        public async Task<IEnumerable<ReservaViewModel>> GetReservas()
        {
            try
            {
                var reservas = await _locacaoVeiculoRepository.GetReservas();
                var reservasVM = new List<ReservaViewModel>();

                foreach (var reserva in reservas)
                {
                    reservasVM.Add(_mapper.Map<ReservaViewModel>(reserva));
                }

                return reservasVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ReservaViewModel>> GetReservasByCliente(string token)
        {
            try
            {
                var clienteId = await _utilService.GetUserByToken(token);
                var reservas = await _locacaoVeiculoRepository.GetReservasByCliente(clienteId.Id);
                var reservasVM = new List<ReservaViewModel>();

                foreach (var reserva in reservas)
                {
                    reservasVM.Add(_mapper.Map<ReservaViewModel>(reserva));
                }

                return reservasVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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



