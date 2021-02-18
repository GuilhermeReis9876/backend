using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.ViewModels;
using AutoMapper;
using CpfLibrary;
using Microsoft.AspNetCore.Http;

namespace api.Application.Services
{
    public class UtilService : IUtilService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IOperadorRepository _operadorRepository;
        private readonly IMapper _mapper;

        public UtilService(IClienteRepository clienteRepository, IOperadorRepository operadorRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _operadorRepository = operadorRepository;
            _mapper = mapper;
        }

        public async Task<UserInfoViewModel> GetUserByToken(string token)
        {
            var tokenValue = token.Substring(7);
            var tokenJwt = new JwtSecurityToken(jwtEncodedString: tokenValue);
            var userRegister = tokenJwt.Claims.Where(c => c.Type == "nameid").FirstOrDefault().Value;
            userRegister = userRegister.Replace(".", "").Replace("-", "");
            if(Cpf.Check(userRegister))
            {
                return _mapper.Map<UserInfoViewModel>
                    (
                        await _clienteRepository.UserExists(userRegister)
                    );
            }
            else
            {
                return _mapper.Map<UserInfoViewModel>
                    (
                        await _operadorRepository.UserExists(userRegister)
                    );
            }
            
            
        }
        
    }
}