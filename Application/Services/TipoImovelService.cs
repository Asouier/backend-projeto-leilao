using Application.DTOs.TipoImoveis;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class TipoImovelService
    {
        private readonly ITipoImovelRepository _tipoImovelRepository;

        public TipoImovelService(ITipoImovelRepository tipoImovelRepository)
        {
            _tipoImovelRepository = tipoImovelRepository;
        }

        public async Task<string> AddTipoImovel(string novoTipoImovel)
        {
            try
            {
                var tipoImovel = TipoImovel.Create(novoTipoImovel);

                await _tipoImovelRepository.Add(tipoImovel);
                return "Tipo de imóvel adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar tipo de imóvel: {ex.Message}";
            }
        }

        public async Task<string> UpdateTipoImovel(UpdateTipoImovelDto novosDados)
        {
            try
            {
                var tipoImovel = await _tipoImovelRepository.GetById(novosDados.Id);
                if (tipoImovel == null)
                {
                    return "Tipo de imóvel não encontrado.";
                }

                tipoImovel.AtualizarPropriedadesNaoNulas(novosDados);

                await _tipoImovelRepository.Update(tipoImovel);
                return "Tipo de imóvel atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar tipo de imóvel: {ex.Message}";
            }
        }

        public async Task<string> RemoveTipoImovel(int id)
        {
            try
            {
                var tipoImovel = await _tipoImovelRepository.GetById(id);
                if (tipoImovel == null)
                {
                    return "Tipo de imóvel não encontrado.";
                }

                await _tipoImovelRepository.Remove(tipoImovel.Id);
                return "Tipo de imóvel removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover tipo de imóvel: {ex.Message}";
            }
        }

        public async Task<TipoImovel?> GetTipoImovelById(int id)
        {
            return await _tipoImovelRepository.GetById(id);
        }

        public async Task<List<TipoImovel>> GetAllTipoImoveis()
        {
            return await _tipoImovelRepository.GetAll();
        }
    }
}