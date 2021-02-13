using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
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
            try
            {
                return await _clienteRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Save(UsuarioViewModel clienteVM)
        {
            var hmac = new HMACSHA512();
            var cliente = new Cliente()
            {
                Nome = clienteVM.Nome,
                DiaDeNascimento = DateTime.ParseExact(clienteVM.DiaDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Cpf = clienteVM.Cpf,
                PassworkHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(clienteVM.Senha)),
                PasswordSalt = hmac.Key,

            };

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

            try
            {
                await _clienteRepository.Delete(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{cliente.GetType().Name}");
            }
        }

        public async Task Update(Cliente cliente)
        {
            try
            {
                await _clienteRepository.Update(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{cliente.GetType().Name}");
            }
        }
    }
}
