using Application.DTOs.TipoVeiculos;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoVeiculoController : ControllerBase
    {
        private readonly TipoVeiculoService _tipoVeiculoService;

        public TipoVeiculoController(TipoVeiculoService tipoVeiculoService)
        {
            _tipoVeiculoService = tipoVeiculoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddTipoVeiculo([FromBody] string novoTipoVeiculo)
        {
            var resultado = await _tipoVeiculoService.AddTipoVeiculo(novoTipoVeiculo);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateTipoVeiculo([FromBody] UpdateTipoVeiculoDto novosDados)
        {
            var resultado = await _tipoVeiculoService.UpdateTipoVeiculo(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveTipoVeiculo(int id)
        {
            var resultado = await _tipoVeiculoService.RemoveTipoVeiculo(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetTipoVeiculoById(int id)
        {
            var tipoVeiculo = await _tipoVeiculoService.GetTipoVeiculoById(id);
            return Ok(tipoVeiculo);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTipoVeiculos()
        {
            var tipoVeiculos = await _tipoVeiculoService.GetAllTipoVeiculos();
            return Ok(tipoVeiculos);
        }
    }
}