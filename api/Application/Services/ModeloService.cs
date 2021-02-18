using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public async Task<IEnumerable<Modelo>> GetModelos()
        {
            try
            {
                var result = await _modeloRepository.GetAll();

                if (result == null) return null;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Modelo> GetModeloById(int id)
        {
            try
            {
                var result = await _modeloRepository.GetById(id);
                if (result == null) return null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
