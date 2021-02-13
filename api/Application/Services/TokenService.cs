using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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

        public string CreateToken(object usuario)
        {
            var propertyNome = usuario.GetType().GetProperty("Nome");
            var Nome = (string)propertyNome.GetValue(usuario);

            var claims =
                new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.NameId, Nome)
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

    }
}