using Application.DTOs.Leiloes;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class LeilaoService
    {
        private readonly ILeilaoRepository _leilaoRepository;

        public LeilaoService(ILeilaoRepository leilaoRepository)
        {
            _leilaoRepository = leilaoRepository;
        }

        public async Task<string> AddLeilao(AddLeilaoDto novoLeilao)
        {
            try
            {
                var leilao = new Leilao
                {
                    TipoLeilaoId = novoLeilao.TipoLeilaoId,
                    StatusId = novoLeilao.StatusId,
                    EnderecoId = novoLeilao.EnderecoId,
                    DataHoraInicio = novoLeilao.DataHoraInicio,
                    DataHoraFim = novoLeilao.DataHoraFim,
                    UrlLeilao = novoLeilao.UrlLeilao,
                    UsuarioCadastroId = novoLeilao.UsuarioCadastroId,
                    UsuarioAprovacaoId = novoLeilao.UsuarioAprovacaoId,
                    TaxaAdministrativa = novoLeilao.TaxaAdministrativa
                };

                await _leilaoRepository.Add(leilao);
                return "Leilão adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar leilão: {ex.Message}";
            }
        }

        public async Task<string> UpdateLeilao(UpdateLeilaoDto novosDados)
        {
            try
            {
                var leilao = await _leilaoRepository.GetById(novosDados.Id);
                if (leilao == null)
                {
                    return "Leilão não encontrado.";
                }

                leilao.AtualizarPropriedadesNaoNulas(novosDados);

                await _leilaoRepository.Update(leilao);
                return "Leilão atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar leilão: {ex.Message}";
            }
        }

        public async Task<Leilao?> GetLeilaoById(int Id)
        {
            return await _leilaoRepository.GetById(Id);
        }

        public async Task<List<Leilao>> GetAllLeiloes()
        {
            return await _leilaoRepository.GetAll();
        }

        public async Task<List<Leilao>> GetByStatus(int statusId)
        {
            return await _leilaoRepository.GetByStatus(statusId);
        }
        public async Task<List<Leilao>> GetByTipoLeilao(int statusId)
        {
            return await _leilaoRepository.GetByTipoLeilao(statusId);
        }
    }
}