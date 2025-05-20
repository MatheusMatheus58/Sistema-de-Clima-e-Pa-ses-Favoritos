using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Web.DTOS;
using GloboClima.Api.Services;
namespace Web.Controller
{
  

    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        // Simula um usuário válido
        private readonly string usuarioMockEmail = "teste@globo.com";
        private readonly string usuarioMockSenha = "123456";
        private readonly string usuarioMockId = Guid.NewGuid().ToString();

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Email == usuarioMockEmail && request.Senha == usuarioMockSenha)
            {
                var token = _jwtService.GerarToken(usuarioMockId, request.Email);
                return Ok(new LoginResponse { Token = token });
            }

            return Unauthorized("Credenciais inválidas");
        }

        private IActionResult Unauthorized(string v)
        {
            throw new NotImplementedException();
        }
    }

}


