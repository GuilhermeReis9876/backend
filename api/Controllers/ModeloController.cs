using api.Application.Interfaces;
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

    public class ModeloController : BaseApiController
    {
        private IModeloService _modeloService;
        private IMapper _mapper;

        public ModeloController(
            ILogger<ModeloController> logger,
            IModeloService service,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _modeloService = service;
        }

        [Route("List")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ModeloViewModel>> GetAll()
        {
            try
            {
                var modelos = await _modeloService.GetModelos();
                var modelosVM = new List<ModeloViewModel>();

                foreach (var modelo in modelos)
                {
                    modelosVM.Add(_mapper.Map<ModeloViewModel>(modelo));
                }

                return modelosVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ModeloViewModel> GetById(int id)
        {
            try
            {
                var modelos = await _modeloService.GetModeloById(id);
                ModeloViewModel modelosVM = _mapper.Map<ModeloViewModel>(modelos);
                return modelosVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
