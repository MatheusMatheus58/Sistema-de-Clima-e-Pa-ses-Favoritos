using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GloboClima.Api.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GerarToken(string usuarioId, string email)
        {
            // Lê a chave do appsettings.json
            var chaveSecreta = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(chaveSecreta))
            {
                throw new Exception("Chave JWT não configurada. Verifique o appsettings.json");
            }

            // Cria a chave simétrica
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            // Define os dados que vão dentro do token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuarioId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}