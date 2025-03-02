using Application.DTOs.TipoLeiloes;
using Application.IServices;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class TipoLeilaoService: ITipoLeilaoService
    {
        private readonly ITipoLeilaoRepository _tipoLeilaoRepository;

        public TipoLeilaoService(ITipoLeilaoRepository tipoLeilaoRepository)
        {
            _tipoLeilaoRepository = tipoLeilaoRepository;
        }

        public async Task<string> AddTipoLeilao(string novoTipoLeilao)
        {
            try
            {
                var tipoLeilao = TipoLeilao.Create(novoTipoLeilao);

                await _tipoLeilaoRepository.Add(tipoLeilao);
                return "Tipo de leilão adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar tipo de leilão: {ex.Message}";
            }
        }

        public async Task<string> UpdateTipoLeilao(UpdateTipoLeilaoDto novosDados)
        {
            try
            {
                var tipoLeilao = await _tipoLeilaoRepository.GetById(novosDados.Id);
                if (tipoLeilao == null)
                {
                    return "Tipo de leilão não encontrado.";
                }

                tipoLeilao.AtualizarPropriedadesNaoNulas(novosDados);

                await _tipoLeilaoRepository.Update(tipoLeilao);
                return "Tipo de leilão atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar tipo de leilão: {ex.Message}";
            }
        }

        public async Task<string> RemoveTipoLeilao(int id)
        {
            try
            {
                var tipoLeilao = await _tipoLeilaoRepository.GetById(id);
                if (tipoLeilao == null)
                {
                    return "Tipo de leilão não encontrado.";
                }

                await _tipoLeilaoRepository.Remove(tipoLeilao.Id);
                return "Tipo de leilão removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover tipo de leilão: {ex.Message}";
            }
        }

        public async Task<TipoLeilao?> GetTipoLeilaoById(int id)
        {
            return await _tipoLeilaoRepository.GetById(id);
        }

        public async Task<List<TipoLeilao>> GetAllTipoLeiloes()
        {
            return await _tipoLeilaoRepository.GetAll();
        }
    }
}