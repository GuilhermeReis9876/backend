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
        [Authorize(Roles = "OPERADOR")]
        public async Task<IEnumerable<UsuarioResponseViewModel>> GetAll()
        {
            var clientes = await _clienteService.GetClientes();
            var clientesVM = new List<UsuarioResponseViewModel>();

            foreach (var cliente in clientes)
            {
                clientesVM.Add(_mapper.Map<UsuarioResponseViewModel>(cliente));
            }

            return clientesVM;
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [Authorize(Roles = "OPERADOR")]
        public async Task<UsuarioResponseViewModel> GetById(int id)
        {
            try
            {
                return _mapper.Map<UsuarioResponseViewModel>(await _clienteService.GetById(id));
            }
            catch (Exception ex)
            {
                return new UsuarioResponseViewModel { Error = ex.Message };
            }
        }

        [Route("Update/{id}")]
        [HttpPut]
        [Authorize(Roles = "OPERADOR, CLIENTE")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateViewModel clienteVM)
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
        [Authorize(Roles = "OPERADOR")]
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
