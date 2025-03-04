using Application.DTOs.Credenciais;
using Application.IServices;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Application.Services
{
    public class CredencialService: ICredencialService
    {
        private readonly ICredencialRepository _credencialRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CredencialService(ICredencialRepository credencialRepository, IClienteRepository clienteRepository, IUsuarioRepository usuarioRepository)
        {
            _credencialRepository = credencialRepository;
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<string> AddCredencial(AddCredencialDto novaCredencial)
        {
            try
            {
                var credencial = Credencial.Create(novaCredencial.NomeUsuario, novaCredencial.Senha);

                await _credencialRepository.Add(credencial);
                return "Credencial adicionada com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar credencial: {ex.Message}";
            }
        }
        public async Task<ResponseLoginDto?> GetAccess(AddCredencialDto credencial)
        {
            try
            {
                var acesso = await _credencialRepository.GetByNomeUsuario(credencial.NomeUsuario);
                if (acesso == null || credencial.Senha != acesso.Senha)
                    return null;

                var contaUsuario = await _usuarioRepository.GetByCredencialId(acesso.Id);
                var contaCliente = new Cliente();
                if (contaUsuario == null)
                {
                    contaCliente = await _clienteRepository.GetByCredencialId(acesso.Id);
                }

                var response = new ResponseLoginDto
                {
                    Id = contaUsuario?.Id ?? contaCliente?.Id,
                    NomeUsuario = acesso.NomeUsuario,
                    Email = contaUsuario?.Contato?.Email ?? contaCliente?.Contato?.Email
                };

                if (contaUsuario != null)
                {
                    response.NomeCompleto = contaUsuario.NomeCompleto;
                    response.CargoFuncao = contaUsuario.CargoFuncao;
                    response.PermissaoId = contaUsuario.PermissaoId;
                    response.RegiaoResponsavel = contaUsuario.RegiaoResponsavel;
                    response.CategoriaResponsavel = contaUsuario.CategoriaResponsavel;
                }

                if (contaCliente != null)
                {
                    response.NomeCompleto = contaCliente.NomeCompleto;
                    response.NomeFantasia = contaCliente.NomeFantasia;
                    response.Cidade = contaCliente.Endereco?.Cidade;
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao realizar login: " + ex.Message);
                return null;
            }
        }
        public async Task<string> UpdateCredencial(UpdateCredencialDto novosDados)
        {
            try
            {
                var credencial = await _credencialRepository.GetById(novosDados.Id);
                if (credencial == null)
                {
                    return "Credencial não encontrada.";
                }

                credencial.AtualizarPropriedadesNaoNulas(novosDados);

                if (!string.IsNullOrEmpty(novosDados.Senha))
                {
                    credencial.AtualizarSenha(novosDados.Senha);
                }

                await _credencialRepository.Update(credencial);
                return "Credencial atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar credencial: {ex.Message}";
            }
        }

        public async Task<string> RemoveCredencial(int id)
        {
            try
            {
                var credencial = await _credencialRepository.GetById(id);
                if (credencial == null)
                {
                    return "Credencial não encontrada.";
                }

                await _credencialRepository.Remove(credencial.Id);
                return "Credencial removida com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover credencial: {ex.Message}";
            }
        }

        public async Task<Credencial?> GetCredencialById(int id)
        {
            return await _credencialRepository.GetById(id);
        }

        public async Task<Credencial?> GetCredencialByNomeUsuario(string nomeUsuario)
        {
            return await _credencialRepository.GetByNomeUsuario(nomeUsuario);
        }
    }
}