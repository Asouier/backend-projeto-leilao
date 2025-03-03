using Application.DTOs.Leiloes;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeilaoController : ControllerBase
    {
        private readonly ILeilaoService _leilaoService;

        public LeilaoController(ILeilaoService leilaoService)
        {
            _leilaoService = leilaoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddLeilao([FromBody] AddLeilaoDto novoLeilao)
        {
            var resultado = await _leilaoService.AddLeilao(novoLeilao);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateLeilao([FromBody] UpdateLeilaoDto dadosAtualizados)
        {
            var resultado = await _leilaoService.UpdateLeilao(dadosAtualizados);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetLeilaoById(int Id)
        {
            var leilao = await _leilaoService.GetLeilaoById(Id);
            return Ok(leilao);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLeiloes()
        {
            var leiloes = await _leilaoService.GetAllLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("status/{status}")]
        public async Task<IActionResult> GetByStatus(int statusId)
        {
            var leiloes = await _leilaoService.GetByStatus(statusId);
            return Ok(leiloes);
        }

        [HttpGet("tipo/{tipoLeilaoId}")]
        public async Task<IActionResult> GetByTipoLeilao(int tipoLeilaoId)
        {
            var leiloes = await _leilaoService.GetByTipoLeilao(tipoLeilaoId);
            return Ok(leiloes);
        }
    }
}