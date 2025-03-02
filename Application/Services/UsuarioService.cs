using Application.DTOs.Usuarios;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> AddUsuario(AddUsuarioDto novoUsuario)
        {
            try
            {
                var usuario = new Usuario
                {
                    NomeCompleto = novoUsuario.NomeCompleto,
                    Cpf = novoUsuario.Cpf,
                    Rg = novoUsuario.Rg,
                    CargoFuncao = novoUsuario.CargoFuncao,
                    EntidadeResponsavel = novoUsuario.EntidadeResponsavel,
                    CredencialId = novoUsuario.CredencialId,
                    ContatoId = novoUsuario.ContatoId,
                    PermissaoId = novoUsuario.PermissaoId,
                    UsuarioConcessaoId = novoUsuario.UsuarioConcessaoId,
                    RegiaoResponsavel = novoUsuario.RegiaoResponsavel,
                    CategoriaResponsavel = novoUsuario.CategoriaResponsavel
                };

                await _usuarioRepository.Add(usuario);
                return "Usuário adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar usuário: {ex.Message}";
            }
        }

        public async Task<string> UpdateUsuario(string cpf, UpdateUsuarioDto dadosAtualizados)
        {
            try
            {
                var usuario = await _usuarioRepository.GetByCpf(cpf);
                if (usuario == null)
                {
                    return "Usuário não encontrado.";
                }

                usuario.AtualizarPropriedadesNaoNulas(dadosAtualizados);

                await _usuarioRepository.Update(usuario);
                return $"O usuário {usuario.NomeCompleto} com o CPF {usuario.Cpf} foi atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar usuário: {ex.Message}";
            }
        }

        public async Task<string> RemoveUsuario(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetById(id);
                if (usuario == null)
                {
                    return "Usuário não encontrado.";
                }

                await _usuarioRepository.Remove(usuario.Id);
                return $"O usuário {usuario.NomeCompleto} com o CPF {usuario.Cpf} foi removido com sucesso!";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover usuário: {ex.Message}";
            }
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<Usuario?> GetUsuarioByCpf(string cpf)
        {
            return await _usuarioRepository.GetByCpf(cpf);
        }
    }
}