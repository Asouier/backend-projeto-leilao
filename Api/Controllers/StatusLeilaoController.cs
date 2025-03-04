using Application.DTOs.StatusLeiloes;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StatusLeilaoController : ControllerBase
    {
        private readonly IStatusLeilaoService _statusLeilaoService;

        public StatusLeilaoController(IStatusLeilaoService statusLeilaoService)
        {
            _statusLeilaoService = statusLeilaoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddStatusLeilao([FromBody] string novoStatusLeilao)
        {
            var resultado = await _statusLeilaoService.AddStatusLeilao(novoStatusLeilao);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateStatusLeilao([FromBody] UpdateStatusLeilaoDto novosDados)
        {
            var resultado = await _statusLeilaoService.UpdateStatusLeilao(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveStatusLeilao(int id)
        {
            var resultado = await _statusLeilaoService.RemoveStatusLeilao(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetStatusLeilaoById(int id)
        {
            var statusLeilao = await _statusLeilaoService.GetStatusLeilaoById(id);
            return Ok(statusLeilao);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllStatusLeiloes()
        {
            var statusLeiloes = await _statusLeilaoService.GetAllStatusLeiloes();
            return Ok(statusLeiloes);
        }
    }
}