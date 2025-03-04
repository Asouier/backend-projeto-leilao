using Application.DTOs.Leiloes;
using Application.IServices;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class LeilaoService: ILeilaoService
    {
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly AppDbContext _context;

        public LeilaoService(ILeilaoRepository leilaoRepository, AppDbContext context)
        {
            _leilaoRepository = leilaoRepository;
            _context = context;
        }

        public async Task<string> AddLeilao(AddLeilaoDto novoLeilao)
        {
            var executionStrategy = _context.Database.CreateExecutionStrategy();

            return await executionStrategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (novoLeilao == null)
                    {
                        throw new ArgumentException("Dados do leilão inválidos.");
                    }

                    if (novoLeilao.TipoLeilaoId <= 0)
                    {
                        throw new ArgumentException("Tipo de leilão inválido.");
                    }

                    if (novoLeilao.StatusId <= 0)
                    {
                        throw new ArgumentException("Status inválido.");
                    }

                    if (novoLeilao.UsuarioCadastroId <= 0)
                    {
                        throw new ArgumentException("Usuário de cadastro inválido.");
                    }

                    if (novoLeilao.DataHoraInicio >= novoLeilao.DataHoraFim)
                    {
                        throw new ArgumentException("A data de início deve ser anterior à data de término.");
                    }

                    if (novoLeilao.DataHoraInicio < DateTime.Now || novoLeilao.DataHoraFim < DateTime.Now)
                    {
                        throw new ArgumentException("As datas devem ser futuras.");
                    }

                    var novoEndereco = new Endereco()
                    {
                        Cep = novoLeilao.Cep,
                        Descricao = novoLeilao.Endereco,
                        Cidade = novoLeilao.Cidade,
                        Estado = novoLeilao.Estado,
                        Pais = novoLeilao.Pais,
                        Numero = novoLeilao.Numero
                    };
                    _context.Enderecos.Add(novoEndereco);
                    await _context.SaveChangesAsync();

                    var leilao = new Leilao
                    {
                        TipoLeilaoId = novoLeilao.TipoLeilaoId,
                        StatusId = novoLeilao.StatusId,
                        EnderecoId = novoEndereco.Id,
                        DataHoraInicio = novoLeilao.DataHoraInicio,
                        DataHoraFim = novoLeilao.DataHoraFim,
                        UrlLeilao = novoLeilao.UrlLeilao,
                        UsuarioCadastroId = novoLeilao.UsuarioCadastroId,
                        UsuarioAprovacaoId = novoLeilao.UsuarioAprovacaoId,
                        TaxaAdministrativa = novoLeilao.TaxaAdministrativa
                    };

                    int novoId = await _leilaoRepository.Add(leilao);

                    await transaction.CommitAsync();
                    return $"#{novoId}";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Nenhuma exceção interna.";
                    return $"Erro ao adicionar leilão: {ex.Message}; Exceção interna: {innerExceptionMessage}";
                }
            });
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