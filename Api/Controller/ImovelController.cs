using Application.DTOs.Imoveis;
using Application.Models.Imoveis;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImovelController : ControllerBase
    {
        private readonly ImovelService _imovelService;

        public ImovelController(ImovelService imovelService)
        {
            _imovelService = imovelService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddImovel([FromBody] AddImovelDto novoImovel)
        {
            var resultado = await _imovelService.AddImovel(novoImovel);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateImovel([FromBody] UpdateImovelDto novosDados)
        {
            var resultado = await _imovelService.UpdateImovel(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveImovel(int id)
        {
            var resultado = await _imovelService.RemoveImovel(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetImovelById(int id)
        {
            var imovel = await _imovelService.GetImovelById(id);
            return Ok(imovel);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllImoveis()
        {
            var imoveis = await _imovelService.GetAllImoveis();
            return Ok(imoveis);
        }

        [HttpGet("filtrar-por-leilao/{leilaoId}")]
        public async Task<IActionResult> GetImoveisByLeilao(int leilaoId)
        {
            var imoveis = await _imovelService.GetImoveisByLeilao(leilaoId);
            return Ok(imoveis);
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetImoveisByStatus(int statusId)
        {
            var imoveis = await _imovelService.GetImoveisByStatus(statusId);
            return Ok(imoveis);
        }
    }
}