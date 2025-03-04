using Application.DTOs.TipoImoveis;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TipoImovelController : ControllerBase
    {
        private readonly ITipoImovelService _tipoImovelService;

        public TipoImovelController(ITipoImovelService tipoImovelService)
        {
            _tipoImovelService = tipoImovelService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddTipoImovel([FromBody] string novoTipoImovel)
        {
            var resultado = await _tipoImovelService.AddTipoImovel(novoTipoImovel);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateTipoImovel([FromBody] UpdateTipoImovelDto novosDados)
        {
            var resultado = await _tipoImovelService.UpdateTipoImovel(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveTipoImovel(int id)
        {
            var resultado = await _tipoImovelService.RemoveTipoImovel(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetTipoImovelById(int id)
        {
            var tipoImovel = await _tipoImovelService.GetTipoImovelById(id);
            return Ok(tipoImovel);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTipoImoveis()
        {
            var tipoImoveis = await _tipoImovelService.GetAllTipoImoveis();
            return Ok(tipoImoveis);
        }
    }
}