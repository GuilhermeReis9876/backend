using api.Application.Interfaces;
using api.Domain.Interfaces;
using api.Domain.Models;
using api.Domain.ViewModels;
using AutoMapper;
using CpfLibrary;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IClienteRepository _clienteRepository;
        private readonly IOperadorRepository _operadorRepository;
        private readonly IMapper _mapper;

        public TokenService(IConfiguration config, IClienteRepository clienteRepository, IOperadorRepository operadorRepository, IMapper mapper)
        {
            _key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _clienteRepository = clienteRepository;
            _operadorRepository = operadorRepository;
            _mapper = mapper;
        }

        public string CreateToken(object usuario, EnumTipoDeUsuario tipoDeUsuario, string register)
        {

            var claims =
                new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.NameId, register),
                    new Claim(ClaimTypes.Role, tipoDeUsuario.ToString())
                };

            // Creating Credentials
            var creds =
                new SigningCredentials(_key,
                    SecurityAlgorithms.HmacSha512Signature);

            // Describing token
            var tokenDescriptor =
                new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(3),
                    SigningCredentials = creds
                };

            var tokenHandler = new JwtSecurityTokenHandler();

            //Create and return token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public async Task<object> GetUserByToken(string token)
        {
            var tokenValue = token.Substring(7);
            var tokenJwt = new JwtSecurityToken(jwtEncodedString: tokenValue);
            var userRegister = tokenJwt.Claims.Where(c => c.Type == "nameid").FirstOrDefault().Value;
            userRegister = userRegister.Replace(".", "").Replace("-", "");
            if (Cpf.Check(userRegister))
            {
                return _mapper.Map<UserInfoViewModel>
                    (
                        await _clienteRepository.GetUserByRegister(userRegister)
                    );
            }
            else
            {
                return _mapper.Map<UserInfoViewModel>
                    (
                        await _operadorRepository.GetUserByRegister(userRegister)
                    );
            }


        }

    }
}