using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _VeiculoRepository;

        public VeiculoService(IVeiculoRepository VeiculoRepository)
        {
            _VeiculoRepository = VeiculoRepository;
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculos()
        {
            try
            {
                var result = await _VeiculoRepository.GetAll();

                if (result == null) return null;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Veiculo> GetVeiculoById(int id)
        {
            try
            {
                var result = await _VeiculoRepository.GetById(id);
                if (result == null) return null;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculoByCategoria(EnumTipoDeVeiculo id)
        {
            try
            {
                var result = await _VeiculoRepository.GetVeiculosByCategoria(id);
                if (result == null) return null;
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
