using api.Controllers;
using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{

    public class ClienteController : BaseApiController
    {
        private IClienteService _clienteService;
        private ILoginService _loginService;
        private IMapper _mapper;

        public ClienteController(
            ILogger<ClienteController> logger,
            IClienteService service,
            ILoginService loginService,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _clienteService = service;
            _loginService = loginService;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> GetAll()
        {
            var clientes = await _clienteService.GetClientes();
            var clientesVM = new List<UsuarioViewModel>();

            foreach (var cliente in clientes)
            {
                clientesVM.Add(_mapper.Map<UsuarioViewModel>(cliente));
            }

            return clientesVM;
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [Authorize]
        public async Task<UsuarioViewModel> GetById(int id)
        {
            try
            {
                return _mapper.Map<UsuarioViewModel>(await _clienteService.GetById(id));
            }
            catch (Exception ex)
            {
                return new UsuarioViewModel { Error = ex.Message };
            }
        }

        //[Route("Create")]
        //[HttpPost]
        //public async Task<IActionResult> Save([FromBody] UsuarioViewModel clienteVM)
        //{
        //    try
        //    {

        //        if (await _loginService.UserExists(clienteVM.Cpf))
        //            return BadRequest("Usu�rio j� cadastrado!");

        //        await _clienteService.Save(clienteVM);
        //        return StatusCode(200, $"{clienteVM.Nome} adicionado com sucesso!");
        //    }
        //    catch (AutoMapperMappingException amex)
        //    {
        //        return StatusCode(400, amex.InnerException.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, ex.Message);
        //    }

        //}

        [Route("Update/{id}")]
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioViewModel clienteVM)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteVM);

                cliente.Id = id;
                await _clienteService.Update(cliente);

                return StatusCode(200, "atualizado com sucesso!");
            }
            catch (AutoMapperMappingException amex)
            {
                return StatusCode(400, amex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }

        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.Delete(await _clienteService.GetById(id));

                return StatusCode(200, "Deletado com sucesso!");
            }
            catch (AutoMapperMappingException amex)
            {
                return StatusCode(400, amex.InnerException.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

    }
}
