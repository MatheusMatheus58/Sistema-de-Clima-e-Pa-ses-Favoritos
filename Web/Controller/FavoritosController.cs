using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoritosController : ControllerBase
{
    [HttpGet]
    public IActionResult GetFavoritos()
    {
        // Sem FindFirstValue – acessa diretamente as claims
        var usuarioId = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;

        var favoritos = new List<object>
        {
            new { Tipo = "Cidade", Nome = "São Paulo" },
            new { Tipo = "País", Nome = "Japão" }
        };

        return Ok(new
        {
            UsuarioId = usuarioId,
            Favoritos = favoritos
        });
    }
}