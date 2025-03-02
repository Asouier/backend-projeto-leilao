using Application.DTOs.Permissoes;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    public class PermissaoService
    {
        private readonly IPermissaoRepository _permissaoRepository;

        public PermissaoService(IPermissaoRepository permissaoRepository)
        {
            _permissaoRepository = permissaoRepository;
        }

        public async Task<string> AddPermissao(string novaPermissao)
        {
            try
            {
                var permissao = Permissao.Create(novaPermissao);
                await _permissaoRepository.Add(permissao);

                return "Novo nivel de permissão adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar permissão: {ex.Message}";
            }
        }

        public async Task<string> UpdatePermissao(UpdatePermissaoDto novosDados)
        {
            try
            {
                var permissao = await _permissaoRepository.GetById(novosDados.Id);
                if (permissao == null)
                {
                    return "Permissão não encontrada.";
                }

                permissao.Update(novosDados.Descricao);

                await _permissaoRepository.Update(permissao);
                return "Permissão atualizada com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar permissão: {ex.Message}";
            }
        }

        public async Task<string> RemovePermissao(int id)
        {
            try
            {
                var permissao = await _permissaoRepository.GetById(id);
                if (permissao == null)
                {
                    return "Permissão não encontrada.";
                }

                await _permissaoRepository.Remove(permissao.Id);
                return "Permissão removida com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover permissão: {ex.Message}";
            }
        }

        public async Task<Permissao?> GetPermissaoById(int id)
        {
            return await _permissaoRepository.GetById(id);
        }

        public async Task<List<Permissao>> GetAllPermissoes()
        {
            return await _permissaoRepository.GetAll();
        }
    }
}