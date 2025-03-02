using Application.DTOs.TipoLeiloes;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoLeilaoController : ControllerBase
    {
        private readonly TipoLeilaoService _tipoLeilaoService;

        public TipoLeilaoController(TipoLeilaoService tipoLeilaoService)
        {
            _tipoLeilaoService = tipoLeilaoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddTipoLeilao([FromBody] string novoTipoLeilao)
        {
            var resultado = await _tipoLeilaoService.AddTipoLeilao(novoTipoLeilao);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateTipoLeilao([FromBody] UpdateTipoLeilaoDto novosDados)
        {
            var resultado = await _tipoLeilaoService.UpdateTipoLeilao(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveTipoLeilao(int id)
        {
            var resultado = await _tipoLeilaoService.RemoveTipoLeilao(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetTipoLeilaoById(int id)
        {
            var tipoLeilao = await _tipoLeilaoService.GetTipoLeilaoById(id);
            return Ok(tipoLeilao);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllTipoLeiloes()
        {
            var tipoLeiloes = await _tipoLeilaoService.GetAllTipoLeiloes();
            return Ok(tipoLeiloes);
        }
    }
}