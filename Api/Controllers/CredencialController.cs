using Application.DTOs.Credenciais;
using Domain.Entities;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CredencialController : ControllerBase
    {
        private readonly ICredencialService _credencialService;

        public CredencialController(ICredencialService credencialService)
        {
            _credencialService = credencialService;
        }

        [HttpGet("acesso")]
        public async Task<IActionResult> GetAccess(Credencial credencial)
        {
            var resultado = await _credencialService.GetAccess(credencial);
            return Ok(resultado);
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddCredencial([FromBody] AddCredencialDto novaCredencial)
        {
            var resultado = await _credencialService.AddCredencial(novaCredencial);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateCredencial([FromBody] UpdateCredencialDto novosDados)
        {
            var resultado = await _credencialService.UpdateCredencial(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveCredencial(int id)
        {
            var resultado = await _credencialService.RemoveCredencial(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetCredencialById(int id)
        {
            var credencial = await _credencialService.GetCredencialById(id);
            return Ok(credencial);
        }

        [HttpGet("filtrar-por-nome-usuario/{nomeUsuario}")]
        public async Task<IActionResult> GetCredencialByNomeUsuario(string nomeUsuario)
        {
            var credencial = await _credencialService.GetCredencialByNomeUsuario(nomeUsuario);
            return Ok(credencial);
        }
    }
}