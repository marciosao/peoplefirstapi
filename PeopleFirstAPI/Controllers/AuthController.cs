using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using PeopleFirstAPI.Configurations;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;


[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtSettings _jwtSettings;
    // private readonly IColaboradorRepository _colaboradorRepository;
    private readonly IColaboradorAppService _colaboradorRepository;

    // public AuthController(IOptions<JwtSettings> jwtSettings)
    // {
    //     _jwtSettings = jwtSettings.Value;
    //     _colaboradorRepository = colaboradorRepository;
    // }


    public AuthController(IOptions<JwtSettings> jwtSettings, IColaboradorAppService colaboradorRepository)
    {
        _jwtSettings = jwtSettings.Value;
        _colaboradorRepository = colaboradorRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            return BadRequest("Email e senha são obrigatórios.");

        var colaborador = await _colaboradorRepository.BuscarPorEmail(request.Username);

        if (colaborador == null || !PasswordHasher.Verify(request.Username, colaborador.SenhaHash))
            return Unauthorized("Usuário ou senha inválidos.");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, colaborador.Nome),
                new Claim(ClaimTypes.NameIdentifier, colaborador.Id.ToString()),
                // new Claim(ClaimTypes.Role, colaborador.PerfilNome) // ou PerfilId
                new Claim(ClaimTypes.Role, colaborador.PerfilNome ?? "")

            }),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { Token = tokenHandler.WriteToken(token) });        
    }
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
