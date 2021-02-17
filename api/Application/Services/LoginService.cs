using api.Domain.ViewModels;
using api.Application.Interfaces;
using CpfLibrary;
using api.Domain.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class LoginService : ILoginService
    {
        private IClienteRepository _clienteRepository;
        public ITokenService _tokenService;
        public IOperadorRepository _operadorRepository;

        public LoginService(IClienteRepository clienteRepository, ITokenService tokenService, IOperadorRepository operadorRepository)
        {
            _clienteRepository = clienteRepository;
            _tokenService = tokenService;
            _operadorRepository = operadorRepository;
        }

        public async Task<LoginViewModel> ValidateUser(string login, string senha)
        {
            var cliente = await _clienteRepository.UserExists(login);
            if (cliente == null)
            {
                var operador = await _operadorRepository.UserExists(login);
                if (operador == null)
                    throw new Exception("Usu�rio n�o existe!");
                else
                {
                    var hmac = new HMACSHA512(operador.PasswordSalt);

                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != operador.PasswordHash[i]) throw new NotImplementedException();
                    }

                    return new LoginViewModel
                    {
                        Usuario = login,
                        Token = _tokenService.CreateToken(operador)
                    };


                }
            }
            else
            {
                var hmac = new HMACSHA512(cliente.PasswordSalt);

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != cliente.PasswordHash[i]) throw new NotImplementedException();
                }

                return new LoginViewModel
                {
                    Usuario = login,
                    Token = _tokenService.CreateToken(cliente)
                };

            }




        }

        public async Task<bool> UserExists(string login)
        {
            if (Cpf.Check(login))
                if (await _clienteRepository.UserExists(login) != null)
                    return true;
                else
                    return false;
            else
                if (await _operadorRepository.UserExists(login) != null)
                return true;
            else
                return false;

        }
    }
}