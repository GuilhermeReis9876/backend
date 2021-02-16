using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using api.Controllers;
using api.Domain.ViewModels;
using Domain.ViewModels;
using api.Models.Entities;

namespace Controllers
{
    public class VeiculoController : BaseApiController
    {
        private IVeiculoService _veiculoService;

        private IEnumService _enumService;

        private IMapper _mapper;

        public VeiculoController(
            ILogger<VeiculoController> logger,
            IVeiculoService service,
            IEnumService enumService,
            IMapper mapper
        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _veiculoService = service;
            _enumService = enumService;
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
                VeiculoViewModel veiculosVM =
                    _mapper.Map<VeiculoViewModel>(veiculos);
                return veiculosVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("Categorias")]
        [HttpGet]
        public List<EnumViewModel> GetCategorias()
        {
            return _enumService.GetValues<EnumTipoDeVeiculo>();
        }

        [Route("Combustiveis")]
        [HttpGet]
        public List<EnumViewModel> GetCombustiveis()
        {
            return _enumService.GetValues<EnumTipoDeCombustivel>();
        }
    }
}
