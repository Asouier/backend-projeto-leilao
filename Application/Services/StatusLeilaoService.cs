using Application.DTOs.StatusLeiloes;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class StatusLeilaoService
    {
        private readonly IStatusLeilaoRepository _statusLeilaoRepository;

        public StatusLeilaoService(IStatusLeilaoRepository statusLeilaoRepository)
        {
            _statusLeilaoRepository = statusLeilaoRepository;
        }

        public async Task<string> AddStatusLeilao(string novoStatusLeilao)
        {
            try
            {
                var statusLeilao = StatusLeilao.Create(novoStatusLeilao);

                await _statusLeilaoRepository.Add(statusLeilao);
                return "Status de leilão adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar status de leilão: {ex.Message}";
            }
        }

        public async Task<string> UpdateStatusLeilao(UpdateStatusLeilaoDto novosDados)
        {
            try
            {
                var statusLeilao = await _statusLeilaoRepository.GetById(novosDados.Id);
                if (statusLeilao == null)
                {
                    return "Status de leilão não encontrado.";
                }

                statusLeilao.AtualizarPropriedadesNaoNulas(novosDados);

                await _statusLeilaoRepository.Update(statusLeilao);
                return "Status de leilão atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar status de leilão: {ex.Message}";
            }
        }

        public async Task<string> RemoveStatusLeilao(int id)
        {
            try
            {
                var statusLeilao = await _statusLeilaoRepository.GetById(id);
                if (statusLeilao == null)
                {
                    return "Status de leilão não encontrado.";
                }

                await _statusLeilaoRepository.Remove(statusLeilao.Id);
                return "Status de leilão removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover status de leilão: {ex.Message}";
            }
        }

        public async Task<StatusLeilao?> GetStatusLeilaoById(int id)
        {
            return await _statusLeilaoRepository.GetById(id);
        }

        public async Task<List<StatusLeilao>> GetAllStatusLeiloes()
        {
            return await _statusLeilaoRepository.GetAll();
        }
    }
}