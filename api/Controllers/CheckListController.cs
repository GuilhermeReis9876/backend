using api.Application.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class CheckListController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ICheckListService _checkListService;

        public CheckListController(
            ILogger<LocacaoController> logger,
            ICheckListService checkListService,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _checkListService = checkListService;
        }

        [HttpPost("checkLiberacao")]
        [Authorize(Roles = "OPERADOR")]
        public async Task<ActionResult> RegistrarLiberacao([FromBody] CheckListViewModel cl)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            // var checkList = _mapper.Map<CheckList>(cl);
            var checkList = new CheckList()
            {
                EstaLimpo = cl.EstaLimpo,
                EstaComTanqueCheio = cl.EstaComTanqueCheio,
                EstaSemAmassados = cl.EstaSemAmassados,
                EstaSemArranhoes = cl.EstaSemArranhoes,
                LocacaoVeiculoId = cl.LocacaoVeiculoId
            };
            await _checkListService.RegistrarLiberacao(checkList, token);
            return StatusCode(200, "O CheckList de liberação do veículo foi efetuado com sucesso!");
        }

        [HttpPost("checkRetorno")]
        [Authorize(Roles = "OPERADOR")]
        public async Task<ActionResult> RegistraRetorno([FromBody] CheckListViewModel cl)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            // var checkList = _mapper.Map<CheckList>(cl);
            var checkList = new CheckList()
            {
                EstaLimpo = cl.EstaLimpo,
                EstaComTanqueCheio = cl.EstaComTanqueCheio,
                EstaSemAmassados = cl.EstaSemAmassados,
                EstaSemArranhoes = cl.EstaSemArranhoes,
                LocacaoVeiculoId = cl.LocacaoVeiculoId
            };
            await _checkListService.RegistrarRetorno(checkList, token);
            return StatusCode(200, "O CheckList de retorno do veículo foi efetuado com sucesso!");
        }

    }
}
