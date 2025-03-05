using Application.DTOs.Credenciais;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class CredencialController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ICredencialService _credencialService;

    public CredencialController(ICredencialService credencialService, IConfiguration configuration)
    {
        _credencialService = credencialService;
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpGet("tokenParaTeste/desenvolvimento")]
    public async Task<IActionResult> GetToken()
    {
        var token = GenerateJwtToken("administrador");
        return Ok(new { Token = token });
    }

    [AllowAnonymous]
    [HttpPost("acesso")]
    public async Task<IActionResult> GetAccess([FromBody] LoginDto credencial)
    {
        if (credencial == null)
        {
            return BadRequest("Credenciais não fornecidas.");
        }

        var resultado = await _credencialService.GetAccess(credencial);
        if (resultado == null)
        {
            return Unauthorized("O nome de usuário e a senha são incompatíveis.");
        }

        var token = GenerateJwtToken(credencial.NomeUsuario);
        return Ok(new { resultado, Token = token });
    }


    [Authorize]
    [HttpPost("adicionar")]
    public async Task<IActionResult> AddCredencial([FromBody] AddCredencialDto novaCredencial)
    {
        var resultado = await _credencialService.AddCredencial(novaCredencial);
        return Ok(resultado);
    }

    [Authorize]
    [HttpPut("atualizar")]
    public async Task<IActionResult> UpdateCredencial([FromBody] UpdateCredencialDto novosDados)
    {
        var resultado = await _credencialService.UpdateCredencial(novosDados);
        return Ok(resultado);
    }

    [Authorize]
    [HttpDelete("remover/{id}")]
    public async Task<IActionResult> RemoveCredencial(int id)
    {
        var resultado = await _credencialService.RemoveCredencial(id);
        return Ok(resultado);
    }

    [Authorize]
    [HttpGet("numero/{id}")]
    public async Task<IActionResult> GetCredencialById(int id)
    {
        var credencial = await _credencialService.GetCredencialById(id);
        return Ok(credencial);
    }

    [Authorize]
    [HttpGet("filtrar-por-nome-usuario/{nomeUsuario}")]
    public async Task<IActionResult> GetCredencialByNomeUsuario(string nomeUsuario)
    {
        var credencial = await _credencialService.GetCredencialByNomeUsuario(nomeUsuario);
        return Ok(credencial);
    }

    private string GenerateJwtToken(string username)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtSettings["Issuer"],
            Audience = jwtSettings["Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}