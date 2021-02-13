using api.Controllers;
using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{

    public class ClienteController : BaseApiController
    {
        private IClienteService _service;
        private IMapper _mapper;

        public ClienteController(
            ILogger<ClienteController> logger,
            IClienteService service,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _service.GetClientes();
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<Cliente> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] ClienteViewModel clienteVM)
        {
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteVM);
                cliente.TipoDeUsuario = EnumTipoDeUsuario.CLIENTE;

                await _service.Save(cliente);
                return StatusCode(200, $"{cliente.Nome} adicionado com sucesso!");
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

        [Route("Update")]
        [HttpPut]
        public async Task Update([FromBody] Cliente cliente)
        {
            await _service.Update(cliente);
        }

        [Route("Delete")]
        [HttpDelete]
        public async Task Delete([FromBody] Cliente cliente)
        {
            await _service.Delete(cliente);
        }


    }
}
