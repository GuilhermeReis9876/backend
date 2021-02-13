using api.Domain.ViewModels;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using api.Models.Entities;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(Cliente user)
        {
            var claims =
                new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Nome)
                };

            // Creating Credentials
            var creds =
                new SigningCredentials(_key,
                    SecurityAlgorithms.HmacSha512Signature);

            // Describing token
            var tokenDescriptor =
                new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(3),  
                    SigningCredentials = creds
                };

            var tokenHandler = new JwtSecurityTokenHandler();

            //Create and return token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
       
    }
}