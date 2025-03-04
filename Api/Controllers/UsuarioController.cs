using Application.DTOs.Usuarios;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
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
        public async Task<IActionResult> UpdateUsuario([FromBody] UpdateUsuarioDto dadosAtualizados)
        {
            var cpfDescriptografado = EncryptionHelper.Decrypt(dadosAtualizados.Cpf);
            await _usuarioService.UpdateUsuario(dadosAtualizados);
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

        [HttpGet("registro/{credencialId}")]
        public async Task<IActionResult> GetUsuarioByCredencialId(int credencialId)
        {
            var usuario = await _usuarioService.GetUsuarioByCredencialId(credencialId);
            return Ok(usuario);
        }
    }
}