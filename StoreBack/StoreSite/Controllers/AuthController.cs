using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreSite.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreSite.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration Configuration;

    public AuthController(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel loginModel)
    {
        // Vérification des informations d'authentification
        if (string.IsNullOrWhiteSpace(loginModel.Username) || string.IsNullOrWhiteSpace(loginModel.Password))
        {
            return BadRequest("Nom d'utilisateur et mot de passe requis");
        }

        // TODO : Vérifier les informations d'authentification avec votre base de données ou votre système d'authentification

        // Génération d'un token JWT
        var token = GenerateJwtToken(loginModel.Username);

        // Renvoi du token JWT
        return Ok(new { token });
    }

    private string GenerateJwtToken(string username)
    {
        // Récupération de la clé secrète depuis la configuration
        var secretKey = Configuration.GetValue<string>("Jwt:SecretKey");

        // Création des revendications pour le token JWT
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
        };

        // Création de la clé de sécurité à partir de la clé secrète
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        // Création des informations de validation pour le token JWT
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = Configuration.GetValue<string>("Jwt:Issuer"),
            Audience = Configuration.GetValue<string>("Jwt:Audience"),
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(Configuration.GetValue<int>("Jwt:ExpiresInMinutes")),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        };

        // Génération du token JWT
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}