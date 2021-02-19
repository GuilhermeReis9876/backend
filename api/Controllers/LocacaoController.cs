using api.Application.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class LocacaoController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ILocacaoVeiculoService _locacaoVeiculoService;

        private IEnumService _enumService;

        public LocacaoController(
            ILogger<LocacaoController> logger,
            ILocacaoVeiculoService locacaoVeiculoService,
            IMapper mapper,
            IEnumService enumService
        ) :
            base(logger, mapper)
        {
            _locacaoVeiculoService = locacaoVeiculoService;
            _enumService = enumService;
        }


        [Route("Agendar")]
        [HttpPost]
        [Authorize(Roles = "OPERADOR, CLIENTE")]
        public async Task<LocacaoVeiculoViewModel> Agendar([FromBody] LocacaoVeiculoViewModel locacaoVeiculoVM)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"];
                await _locacaoVeiculoService.Agendar(locacaoVeiculoVM, token);
            }
            catch (Exception ex)
            {
                locacaoVeiculoVM.Error = ex.Message;
            }

            return locacaoVeiculoVM;
        }


        [Route("Simular")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<SimulacaoViewModel> Simular([FromBody] SimulacaoViewModel simulacaoVM)
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

        [Route("Status")]
        [HttpGet]
        [AllowAnonymous]
        public List<EnumViewModel> GetStatus()
        {
            return _enumService.GetValues<EnumStatusLocacao>();
        }

        [Route("Reservas")]
        [HttpGet]
        [Authorize(Roles = "OPERADOR")]
        public async Task<IEnumerable<ReservaViewModel>> GetReservas()
        {
            return await _locacaoVeiculoService.GetReservas();
        }

        [Route("Reserva/Cliente")]
        [HttpGet]
        [Authorize(Roles = "CLIENTE")]
        public async Task<IEnumerable<ReservaViewModel>> GetReservasByCliente()
        {
            string token = HttpContext.Request.Headers["Authorization"];
            return await _locacaoVeiculoService.GetReservasByCliente(token);
        }
    }
}
