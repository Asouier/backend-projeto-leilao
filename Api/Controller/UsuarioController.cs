using Application.DTOs.Usuarios;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AddUsuario([FromBody] AddUsuarioDto novoUsuario)
        {
            await _usuarioService.AddUsuario(novoUsuario);
            return Ok("Usuário adicionado com sucesso.");
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> UpdateUsuario([FromBody] string cpf, [FromBody] UpdateUsuarioDto dadosAtualizados)
        {
            var cpfDescriptografado = EncryptionHelper.Decrypt(cpf);
            await _usuarioService.UpdateUsuario(cpfDescriptografado, dadosAtualizados);
            return Ok("Usuário atualizado com sucesso.");
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> RemoveUsuario(int id)
        {
            await _usuarioService.RemoveUsuario(id);
            return Ok("Usuário removido com sucesso.");
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _usuarioService.GetAllUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("buscar/{cpf}")]
        public async Task<IActionResult> GetUsuarioByCpf(string cpf)
        {
            var cpfDescriptografado = EncryptionHelper.Decrypt(cpf);
            var usuario = await _usuarioService.GetUsuarioByCpf(cpfDescriptografado);
            return Ok(usuario);
        }
    }
}