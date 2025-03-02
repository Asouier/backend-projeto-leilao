using Application.DTOs.Veiculos;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _veiculoService;

        public VeiculoController(VeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddVeiculo([FromBody] AddVeiculoDto novoVeiculo)
        {
            var resultado = await _veiculoService.AddVeiculo(novoVeiculo);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateVeiculo([FromBody] UpdateVeiculoDto novosDados)
        {
            var resultado = await _veiculoService.UpdateVeiculo(novosDados);
            return Ok(resultado);
        }
        
        [HttpPut("novoLance")]
        public async Task<IActionResult> NovoLance([FromBody] NovoLanceDto novosLance)
        {
            var resultado = await _veiculoService.NovoLance(novosLance);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveVeiculo(int id)
        {
            var resultado = await _veiculoService.RemoveVeiculo(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetVeiculoById(int id)
        {
            var veiculo = await _veiculoService.GetVeiculoById(id);
            return Ok(veiculo);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllVeiculos()
        {
            var veiculos = await _veiculoService.GetAllVeiculos();
            return Ok(veiculos);
        }

        [HttpGet("filtrar-por-leilao/{leilaoId}")]
        public async Task<IActionResult> GetVeiculosByLeilao(int leilaoId)
        {
            var veiculos = await _veiculoService.GetVeiculosByLeilao(leilaoId);
            return Ok(veiculos);
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetVeiculosByStatus(int statusId)
        {
            var veiculos = await _veiculoService.GetVeiculosByStatus(statusId);
            return Ok(veiculos);
        }
    }
}