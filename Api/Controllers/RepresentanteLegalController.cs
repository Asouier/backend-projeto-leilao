using Application.DTOs.RepresentantesLegais;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RepresentanteLegalController : ControllerBase
    {
        private readonly IRepresentanteLegalService _representanteLegalService;

        public RepresentanteLegalController(IRepresentanteLegalService representanteLegalService)
        {
            _representanteLegalService = representanteLegalService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddRepresentanteLegal([FromBody] AddRepresentanteLegalDto novoRepresentanteLegal)
        {
            var resultado = await _representanteLegalService.AddRepresentanteLegal(novoRepresentanteLegal);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateRepresentanteLegal([FromBody] UpdateRepresentanteLegalDto novosDados)
        {
            var resultado = await _representanteLegalService.UpdateRepresentanteLegal(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveRepresentanteLegal(int id)
        {
            var resultado = await _representanteLegalService.RemoveRepresentanteLegal(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetRepresentanteLegalById(int id)
        {
            var representanteLegal = await _representanteLegalService.GetRepresentanteLegalById(id);
            return Ok(representanteLegal);
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetRepresentanteLegalByCpf(string cpf)
        {
            var representanteLegal = await _representanteLegalService.GetRepresentanteLegalByCpf(cpf);
            return Ok(representanteLegal);
        }
    }
}