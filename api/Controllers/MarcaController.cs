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

    public class MarcaController : BaseApiController
    {
        private IMarcaService _marcaService;
        private IMapper _mapper;

        public MarcaController(
            ILogger<MarcaController> logger,
            IMarcaService service,
            IMapper mapper

        ) :
            base(logger, mapper)
        {
            _mapper = mapper;
            _marcaService = service;
        }

        [Route("List")]
        [HttpGet]
        public async Task<IEnumerable<MarcaViewModel>> GetAll()
        {
            try
            {
                var marcas = await _marcaService.GetMarcas();
                var marcasVM = new List<MarcaViewModel>();

                foreach (var marca in marcas)
                {
                    marcasVM.Add(_mapper.Map<MarcaViewModel>(marca));
                }

                return marcasVM;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<MarcaViewModel> GetById(int id)
        {
            try
            {
                var marcas = await _marcaService.GetMarcaById(id);
                MarcaViewModel marcasVM = _mapper.Map<MarcaViewModel>(marcas);
                return marcasVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
