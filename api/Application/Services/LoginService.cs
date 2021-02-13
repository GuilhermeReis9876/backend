using System;
using System.Threading.Tasks;
using api.Domain.ViewModels;
using api.Models.Entities;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class LoginService: ILoginService
    {
        private IClienteRepository _clienteRepository;
        public ITokenService _tokenService; 

        public LoginService(IClienteRepository clienteRepository, ITokenService tokenService)
        {
            _clienteRepository = clienteRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginViewModel> ValidateUser(string login, string senha)
        {
            var user = await _clienteRepository.UserExists(login);

            if (user == null) throw new NotImplementedException();


            return new LoginViewModel
            {
                Usuario = login,
                Token = _tokenService.CreateToken(user)
            };
        }
    }
}