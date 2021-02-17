using api.Domain.ViewModels;
using api.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class LocacaoController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ILocacaoVeiculoService _locacaoVeiculoService;

        public LocacaoController(
            ILogger<LocacaoController> logger,
            ILocacaoVeiculoService locacaoVeiculoService,
            IMapper mapper

        ) :
            base(logger,mapper)
        {
            _locacaoVeiculoService = locacaoVeiculoService;
        }


        [Route("Agendar")]
        [HttpPost]
        [Authorize]
        public async Task<LocacaoVeiculoViewModel> Agendar(LocacaoVeiculoViewModel locacaoVeiculoVM)
        {
            try
            {
                await _locacaoVeiculoService.Agendar(locacaoVeiculoVM);
            }
            catch (Exception ex)
            {
                locacaoVeiculoVM.Error = ex.Message;
            }

            return locacaoVeiculoVM;
        }


        [Route("Simular")]
        [HttpPost]
        [Authorize]
        public async Task<SimulacaoViewModel> Simular(SimulacaoViewModel simulacaoVM)
        {
            try
            {
                await _locacaoVeiculoService.Simular(simulacaoVM);
            }
            catch (Exception ex)
            {
                simulacaoVM.Error = ex.Message;
            }

            return simulacaoVM;
        }
    }
}
