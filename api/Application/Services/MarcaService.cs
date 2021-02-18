using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<IEnumerable<Marca>> GetMarcas()
        {
            try
            {
                var result = await _marcaRepository.GetAll();

                if (result == null) return null;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Marca> GetMarcaById(int id)
        {
            try
            {
                var result = await _marcaRepository.GetById(id);
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
