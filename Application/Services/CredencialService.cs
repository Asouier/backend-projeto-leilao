using Application.DTOs.Credenciais;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class CredencialService
    {
        private readonly ICredencialRepository _credencialRepository;

        public CredencialService(ICredencialRepository credencialRepository)
        {
            _credencialRepository = credencialRepository;
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