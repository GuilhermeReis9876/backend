using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using Domain.Interfaces;
using System;
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
    }
}
