using Application.DTOs.Contatos;
using Application.Models.Contatos;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoService _contatoService;

        public ContatoController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddContato([FromBody] AddContatoDto novoContato)
        {
            var resultado = await _contatoService.AddContato(novoContato);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateContato([FromBody] UpdateContatoDto novosDados)
        {
            var resultado = await _contatoService.UpdateContato(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveContato(int id)
        {
            var resultado = await _contatoService.RemoveContato(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetContatoById(int id)
        {
            var contato = await _contatoService.GetContatoById(id);
            return Ok(contato);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllContatos()
        {
            var contatos = await _contatoService.GetAllContatos();
            return Ok(contatos);
        }

        [HttpGet("filtrar-por-email/{email}")]
        public async Task<IActionResult> GetContatoByEmail(string email)
        {
            var contato = await _contatoService.GetContatoByEmail(email);
            return Ok(contato);
        }
    }
}