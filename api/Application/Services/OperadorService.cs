using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class OperadorService : IOperadorService
    {
        private readonly IOperadorRepository _operadorRepository;
        public OperadorService(IOperadorRepository operadorRepository)
        {
            _operadorRepository = operadorRepository;
        }

        public async Task Delete(Operador operador)
        {
            try
            {
                await _operadorRepository.Delete(operador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{operador.GetType().Name}");
            }
        }

        public async Task<Operador> GetById(int id)
        {
            try
            {
                return await _operadorRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Operador>> GetOperadores()
        {
            return await _operadorRepository.GetAll();
        }

        public async Task Save(UsuarioViewModel operadorVM)
        {
            var hmac = new HMACSHA512();
            var operador = new Operador()
            {
                Nome = operadorVM.Nome,
                DiaDeNascimento = DateTime.ParseExact(operadorVM.DiaDeNascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Matricula = operadorVM.Matricula,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(operadorVM.Senha)),
                PasswordSalt = hmac.Key,
                TipoDeUsuario = operadorVM.TipoUsuario
            };

            try
            {
                await _operadorRepository.Save(operador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{operador.GetType().Name}");
            }
        }

        public async Task Update(Operador operador)
        {
            try
            {
                await _operadorRepository.Update(operador);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + $"{operador.GetType().Name}");
            }
        }
    }
}
