using api.Models.Entities;
using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Save(Cliente cliente)
        {
            try
            {
                await _clienteRepository.Save(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{cliente.GetType().Name}");
            }

        }

        public async Task Delete(Cliente cliente)
        {
            await _clienteRepository.Delete(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);
        }
    }
}
