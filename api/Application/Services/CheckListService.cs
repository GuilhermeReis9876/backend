using api.Domain.Models;
using api.Application.Interfaces;
using api.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class CheckListService : ICheckListService
    {
        private readonly ICheckListRepository _checkListRepository;
        private readonly ILocacaoVeiculoRepository _locacaoRepository;

        public CheckListService(ICheckListRepository checkListRepository, ILocacaoVeiculoRepository locacaoRepository)
        {
            _checkListRepository = checkListRepository;
            _locacaoRepository = locacaoRepository;
        }

        public async Task RegistrarRetorno(CheckList cl)
        {
            var locacao = await _locacaoRepository.GetById(cl.LocacaoVeiculoId);
            if (locacao == null) throw new Exception("A locação do veículo não foi localizada no sistema");

            try
            {
                var clAux = await _checkListRepository.GetCheckListByLocacaoId(cl.LocacaoVeiculoId);
                if (clAux.Count == 0) throw new Exception("A liberação do veículo não foi efetuada");

                var locacaoValor = locacao.ValorLocacao;

                foreach(var aux in clAux)
                {
                    if(aux.CheckListInicial == false) throw new Exception("O retorno do veículo já foi efetuado");
                    
                    if(aux.EstaComTanqueCheio != cl.EstaComTanqueCheio) locacaoValor += locacao.ValorLocacao * 0.3;
                    if(aux.EstaLimpo != cl.EstaLimpo) locacaoValor += locacao.ValorLocacao * 0.3;
                    if (aux.EstaSemAmassados != cl.EstaSemAmassados) locacaoValor += locacao.ValorLocacao * 0.3;
                    if (aux.EstaSemArranhoes != cl.EstaSemArranhoes) locacaoValor += locacao.ValorLocacao * 0.3;
                }

                cl.CheckListInicial = false;
                await _checkListRepository.Save(cl);

                locacao.ValorLocacao = locacaoValor;            
                locacao.Status = EnumStatusLocacao.Finalizado;
                await _locacaoRepository.Update(locacao);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RegistrarLiberacao(CheckList cl)
        {
            var locacao = await _locacaoRepository.GetById(cl.LocacaoVeiculoId);
            if (locacao == null) throw new Exception("A locação do veículo não foi localizada no sistema");

            try
            {
                var clAux = await _checkListRepository.GetCheckListByLocacaoId(cl.LocacaoVeiculoId);
                if (clAux.Count > 0) throw new Exception("A liberação do veículo já foi efetuada");
                cl.CheckListInicial = true;
                await _checkListRepository.Save(cl);

                locacao.Status = EnumStatusLocacao.Locado;
                await _locacaoRepository.Update(locacao);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
