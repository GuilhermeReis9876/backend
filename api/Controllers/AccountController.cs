using api.Application.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
using AutoMapper;
using CpfLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private IClienteService _clienteService;
        private IMapper _mapper;
        private ILoginService _loginService;
        public IOperadorService _operadorService;
        private ITokenService _tokenService;

        public AccountController(
            ILogger<AccountController> logger,
            IClienteService clienteService,
            IOperadorService operadorService,
            IMapper mapper,
            ILoginService loginService,
            ITokenService tokenService

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _loginService = loginService;
            _operadorService = operadorService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginViewModel>> Login([FromBody] LoginViewModel login)
        {
            try
            {
                return await _loginService.ValidateUser(login.Usuario, login.Senha);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UsuarioViewModel usuarioVM)
        {
            if (string.IsNullOrEmpty(usuarioVM.Nome))
                return BadRequest("Nome é requerido para cadastro!");

            if (usuarioVM.TipoUsuario == EnumTipoDeUsuario.CLIENTE)
            {
                usuarioVM.Cpf = usuarioVM.Cpf.Replace(".", "").Replace("-", "");

                if (Cpf.Check(usuarioVM.Cpf))
                {
                    if (await _loginService.UserExists(usuarioVM.Cpf))
                        return BadRequest($"{usuarioVM.Nome} ja cadastrado!");
                    try
                    {
                        await _clienteService.Save(usuarioVM);
                        return StatusCode(200, $"Cliente {usuarioVM.Nome} criado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                else
                {
                    return BadRequest("CPF inserido n�o � um CPF v�lido!");
                }
            }
            else if (usuarioVM.TipoUsuario == EnumTipoDeUsuario.OPERADOR)
            {
                if (usuarioVM.Matricula == null)
                    return BadRequest($"Matricula n�o pode ser vazia!");

                if (await _loginService.UserExists(usuarioVM.Matricula))
                    return BadRequest($"Operador {usuarioVM.Nome} ja cadastrado!");

                try
                {
                    await _operadorService.Save(usuarioVM);
                    return StatusCode(200, $"Operador {usuarioVM.Nome} criado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest("Não foi possível efetuar o cadastrar");
        }
    }

}
