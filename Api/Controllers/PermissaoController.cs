using Application.DTOs.Permissoes;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissaoController : ControllerBase
    {
        private readonly IPermissaoService _permissaoService;

        public PermissaoController(IPermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddPermissao([FromBody] string novaPermissao)
        {
            var resultado = await _permissaoService.AddPermissao(novaPermissao);
            return Ok(resultado);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdatePermissao([FromBody] UpdatePermissaoDto novosDados)
        {
            var resultado = await _permissaoService.UpdatePermissao(novosDados);
            return Ok(resultado);
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemovePermissao(int id)
        {
            var resultado = await _permissaoService.RemovePermissao(id);
            return Ok(resultado);
        }

        [HttpGet("numero/{id}")]
        public async Task<IActionResult> GetPermissaoById(int id)
        {
            var permissao = await _permissaoService.GetPermissaoById(id);
            return Ok(permissao);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllPermissoes()
        {
            var permissoes = await _permissaoService.GetAllPermissoes();
            return Ok(permissoes);
        }
    }
}