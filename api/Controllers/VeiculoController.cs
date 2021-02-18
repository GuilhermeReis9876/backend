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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
        public List<EnumViewModel> GetCategorias()
        {
            return _enumService.GetValues<EnumTipoDeVeiculo>();
        }

        [Route("Combustiveis")]
        [HttpGet]
        [AllowAnonymous]
        public List<EnumViewModel> GetCombustiveis()
        {
            return _enumService.GetValues<EnumTipoDeCombustivel>();
        }

        [Route("Categoria/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VeiculoViewModel>>> GetVeiculoByCategoria(EnumTipoDeVeiculo id)
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculoByCategoria(id);
                var veiculosVM = new List<VeiculoViewModel>();

                foreach (var veiculo in veiculos)
                {
                    veiculosVM.Add(_mapper.Map<VeiculoViewModel>(veiculo));
                }

                if(veiculosVM == null || veiculosVM.Count == 0) throw new Exception("Não foram encontrados veículos desta categoria");

                return veiculosVM;
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
