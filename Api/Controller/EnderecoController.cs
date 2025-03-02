using Application.DTOs.Enderecos;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _enderecoService;

        public EnderecoController(EnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddEndereco([FromBody] AddEnderecoDto novoEndereco)
        {
            var resultado = await _enderecoService.AddEndereco(novoEndereco);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateEndereco([FromBody] UpdateEnderecoDto novosDados)
        {
            var resultado = await _enderecoService.UpdateEndereco(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveEndereco(int id)
        {
            var resultado = await _enderecoService.RemoveEndereco(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var endereco = await _enderecoService.GetEnderecoById(id);
            return Ok(endereco);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var enderecos = await _enderecoService.GetAllEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("filtrar-por-cep/{cep}")]
        public async Task<IActionResult> GetEnderecosByCep(string cep)
        {
            var enderecos = await _enderecoService.GetEnderecosByCep(cep);
            return Ok(enderecos);
        }

        [HttpGet("filtrar-por-cidade/{cidade}")]
        public async Task<IActionResult> GetEnderecosByCidade(string cidade)
        {
            var enderecos = await _enderecoService.GetEnderecosByCidade(cidade);
            return Ok(enderecos);
        }
    }
}