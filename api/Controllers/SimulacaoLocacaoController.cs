using api.Domain.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class SimulacaoLocacaoController : BaseApiController
    {
        private IMapper _mapper;

        public SimulacaoLocacaoController(
            ILogger<SimulacaoLocacaoController> logger,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public SimulacaoViewModel Simular([FromBody] SimulacaoViewModel simulacaoVM)
        {
            var tempodoAluguel = (simulacaoVM.Saida - simulacaoVM.Entrada).TotalHours;
            // mock valor hora
            simulacaoVM.veiculo.ValorHora = 10;
            simulacaoVM.ValorSimulado = tempodoAluguel * simulacaoVM.veiculo.ValorHora;

            return simulacaoVM;
        }


    }


}
