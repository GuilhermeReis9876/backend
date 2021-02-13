using api.Controllers;
using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using AutoMapper;
using CpfLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Controllers
{
    public class AccountController : BaseApiController
    {
        private IClienteService _clienteService;
        private IMapper _mapper;
        private ILoginService _loginService;
        public IOperadorService _operadorService;

        public AccountController(
            ILogger<AccountController> logger,
            IClienteService clienteService,
            IOperadorService operadorService,
            IMapper mapper,
            ILoginService loginService

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _clienteService = clienteService;
            _loginService = loginService;
            _operadorService = operadorService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginViewModel>> Login(string login, string senha)
        {
            return await _loginService.ValidateUser(login, senha);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioVM)
        {
            if (string.IsNullOrEmpty(usuarioVM.Nome))
                return BadRequest("Nome é requerido para cadastro!");

            if (usuarioVM.TipoUsuario == EnumTipoDeUsuario.CLIENTE)
            {
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
                    return BadRequest("CPF inserido não é um CPF válido!");
                }
            }
            else if (usuarioVM.TipoUsuario == EnumTipoDeUsuario.OPERADOR)
            {
                if (usuarioVM.Matricula == null)
                    return BadRequest($"Matricula não pode ser vazia!");

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
