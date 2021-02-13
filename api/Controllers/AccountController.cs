using api.Controllers;
using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Controllers
{
    public class AccountController : BaseApiController
    {
        private IClienteService _clienteService;
        private IMapper _mapper;
        private ILoginService _loginService;

        public AccountController(
            ILogger<AccountController> logger,
            IClienteService clienteService,
            IMapper mapper,
            ILoginService loginService

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> Login(string login, string senha)
        {
            return await _loginService.ValidateUser(login, senha);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioVM)
        {
            if (usuarioVM.TipoUsu�rio == EnumTipoDeUsuario.CLIENTE)
            {
                if (await _loginService.UserExists(usuarioVM.Cpf))
                    return BadRequest("Usu�rio j� cadastrado!");

                await _clienteService.Save(usuarioVM);
                return StatusCode(200, $"Usu�rio {usuarioVM.Nome} criado com sucesso!");
            }

            if (usuarioVM.TipoUsu�rio == EnumTipoDeUsuario.OPERADOR)
            {
                return BadRequest();
            }

            return BadRequest();
        }
    }
}