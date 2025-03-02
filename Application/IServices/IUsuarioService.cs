using Application.DTOs.Usuarios;
using Domain.Entities;

namespace Application.IServices
{
    public interface IUsuarioService
    {
        Task<Usuario?> GetUsuarioByCpf(string cpf);
        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario?> GetUsuarioByCredencialId(int credencialId);
        Task<string> AddUsuario(AddUsuarioDto usuario);
        Task<string> UpdateUsuario(UpdateUsuarioDto dadosAtualizados);
        Task<string> RemoveUsuario(int id);
    }
}