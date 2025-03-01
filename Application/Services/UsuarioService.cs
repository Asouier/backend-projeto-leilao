using Api.DTOs.Usuarios;
using Domain.Entities;
using Domain.Repositories;
using Domain.Extensions;

namespace Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task AddUsuario(AddUsuarioDto novoUsuario)
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
        }

        public async Task<string> UpdateUsuario(string cpf, UpdateUsuarioDto dadosAtualizados)
        {
            var usuario = await _usuarioRepository.GetByCpf(cpf);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            usuario.AtualizarPropriedadesNaoNulas(dadosAtualizados);

            await _usuarioRepository.Update(usuario);
            return $"O usuário {usuario.NomeCompleto} com o cpf {usuario.Cpf} foi atualizado com sussesso!";
        }

        public async Task<string> RemoveUsuario(int Id)
        {
            Usuario usuario = await _usuarioRepository.GetById(Id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            await _usuarioRepository.Remove(usuario.Id);

            return $"O usuário {usuario.NomeCompleto} com o cpf {usuario.Cpf} foi removido com sussesso!";
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _usuarioRepository.GetAll();
        }

    }
}