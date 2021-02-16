using api.Controllers;
using api.Domain.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers
{

    public class VeiculoController : BaseApiController
    {
        private IVeiculoService _veiculoService;
        private IMapper _mapper;

        public VeiculoController(
            ILogger<VeiculoController> logger,
            IVeiculoService service,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _veiculoService = service;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IEnumerable<VeiculoViewModel>> GetAll()
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculos();
                var veiculosVM = new List<VeiculoViewModel>();

                foreach (var veiculo in veiculos)
                {
                    veiculosVM.Add(_mapper.Map<VeiculoViewModel>(veiculo));
                }

                return veiculosVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<VeiculoViewModel> GetById(int id)
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculoById(id);
                VeiculoViewModel veiculosVM = _mapper.Map<VeiculoViewModel>(veiculos);
                return veiculosVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
