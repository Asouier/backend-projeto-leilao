using Application.DTOs.StatusPropriedades;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class StatusPropriedadeService
    {
        private readonly IStatusPropriedadeRepository _statusPropriedadeRepository;

        public StatusPropriedadeService(IStatusPropriedadeRepository statusPropriedadeRepository)
        {
            _statusPropriedadeRepository = statusPropriedadeRepository;
        }

        public async Task<string> AddStatusPropriedade(string novoStatusPropriedade)
        {
            try
            {
                var statusPropriedade = StatusPropriedade.Create(novoStatusPropriedade);

                await _statusPropriedadeRepository.Add(statusPropriedade);
                return "Status de propriedade adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar status de propriedade: {ex.Message}";
            }
        }

        public async Task<string> UpdateStatusPropriedade(UpdateStatusPropriedadeDto novosDados)
        {
            try
            {
                var statusPropriedade = await _statusPropriedadeRepository.GetById(novosDados.Id);
                if (statusPropriedade == null)
                {
                    return "Status de propriedade não encontrado.";
                }

                statusPropriedade.AtualizarPropriedadesNaoNulas(novosDados);

                await _statusPropriedadeRepository.Update(statusPropriedade);
                return "Status de propriedade atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar status de propriedade: {ex.Message}";
            }
        }

        public async Task<string> RemoveStatusPropriedade(int id)
        {
            try
            {
                var statusPropriedade = await _statusPropriedadeRepository.GetById(id);
                if (statusPropriedade == null)
                {
                    return "Status de propriedade não encontrado.";
                }

                await _statusPropriedadeRepository.Remove(statusPropriedade.Id);
                return "Status de propriedade removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover status de propriedade: {ex.Message}";
            }
        }

        public async Task<StatusPropriedade?> GetStatusPropriedadeById(int id)
        {
            return await _statusPropriedadeRepository.GetById(id);
        }

        public async Task<List<StatusPropriedade>> GetAllStatusPropriedades()
        {
            return await _statusPropriedadeRepository.GetAll();
        }
    }
}