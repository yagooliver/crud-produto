using CrudBackend.Domain.Core.Interface.Servicos;
using CrudBackend.Domain.Core.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudBackend.Application.Servicos
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _config;

        public LoginService(IConfiguration config)
        {
            _config = config;
        }

        public TokenJWT RetornaToken(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return null;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, login),
                };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenJWT(true, encodetoken);
        }
    }
}
