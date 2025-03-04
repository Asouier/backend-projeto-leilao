using Application.DTOs.Imoveis;
using Application.IServices;
using Application.Models.Imoveis;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ImovelService: IImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly AppDbContext _context;

        public ImovelService(IImovelRepository imovelRepository, ILeilaoRepository leilaoRepository, AppDbContext context)
        {
            _imovelRepository = imovelRepository;
            _leilaoRepository = leilaoRepository;
            _context = context;
        }

        public async Task<string> AddImovel(AddImovelDto novoImovel)
        {
            var executionStrategy = _context.Database.CreateExecutionStrategy();

            return await executionStrategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    if (novoImovel == null)
                    {
                        throw new ArgumentException("Dados do imóvel inválidos.");
                    }

                    if (novoImovel.TipoImovelId <= 0)
                    {
                        throw new ArgumentException("Tipo de imóvel inválido.");
                    }

                    if (novoImovel.LeilaoId <= 0)
                    {
                        throw new ArgumentException("Leilão inválido.");
                    }

                    if (novoImovel.UsuarioCadastroId <= 0)
                    {
                        throw new ArgumentException("Usuário de cadastro inválido.");
                    }

                    if (novoImovel.AreaTotal <= 0)
                    {
                        throw new ArgumentException("Área total inválida.");
                    }

                    if (novoImovel.ValorMinimo <= 0)
                    {
                        throw new ArgumentException("Valor mínimo inválido.");
                    }

                    if (string.IsNullOrEmpty(novoImovel.MotivoRecolhimento))
                    {
                        throw new ArgumentException("Motivo de recolhimento inválido.");
                    }

                    var novoEndereco = new Endereco()
                    {
                        Cep = novoImovel.Cep,
                        Descricao = novoImovel.Endereco,
                        Cidade = novoImovel.Cidade,
                        Estado = novoImovel.Estado,
                        Pais = novoImovel.Pais,
                        Numero = novoImovel.Numero
                    };
                    _context.Enderecos.Add(novoEndereco);
                    await _context.SaveChangesAsync();

                    var imovel = new Imovel
                    {
                        TipoImovelId = novoImovel.TipoImovelId,
                        LeilaoId = novoImovel.LeilaoId,
                        EnderecoId = novoEndereco.Id,
                        AreaTotal = novoImovel.AreaTotal,
                        QuantidadeComodos = novoImovel.QuantidadeComodos,
                        ValorMinimo = novoImovel.ValorMinimo,
                        StatusPropriedadeId = novoImovel.StatusPropriedadeId,
                        UsuarioCadastroId = novoImovel.UsuarioCadastroId,
                        DataRecolhimento = novoImovel.DataRecolhimento,
                        MotivoRecolhimento = novoImovel.MotivoRecolhimento
                    };

                    await _imovelRepository.Add(imovel);

                    await transaction.CommitAsync();
                    return "Imóvel adicionado com sucesso.";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Nenhuma exceção interna.";
                    return $"Erro ao adicionar leilão: {ex.Message}; Exceção interna: {innerExceptionMessage}";
                }
            });
        }

        public async Task<string> UpdateImovel(UpdateImovelDto novosDados)
        {
            try
            {
                var imovel = await _imovelRepository.GetById(novosDados.Id);
                if (imovel == null)
                {
                    return "Imóvel não encontrado.";
                }

                var anfitriao = await _leilaoRepository.GetById(imovel.LeilaoId);
                if (anfitriao == null) return "O leilão indicado não existe ou não está disponível";

                imovel.AtualizarPropriedadesNaoNulas(novosDados);

                await _imovelRepository.Update(imovel);
                return "Imóvel atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar imóvel: {ex.Message}";
            }
        }

        public async Task<string> NovoLance(NovoLanceImovelDto informacoesLance)
        {
            try
            {
                var imovel = await _imovelRepository.GetById(informacoesLance.IdImovel);
                if (imovel == null)
                {
                    return "Veículo não encontrado.";
                }

                var anfitriao = await _leilaoRepository.GetById(imovel.LeilaoId);
                if (anfitriao == null) return "O leilão indicado não existe ou não está disponível";
                if (anfitriao.StatusId != 1) // Trocar para um enum
                {
                    return "O Leilão anfitrião não esta mais disponivel, logo não haverão mudanças nas informações do Veiculo";
                }

                if (informacoesLance.ValorDoLance < imovel.ValorMinimo)
                {
                    return "Esse tipo de alteração viola a política de uso do Leilão. Um representante do Leilão entrará em contato com você em breve.";
                    //Adicionar log
                }

                imovel.AtualizarPropriedadesNaoNulas(informacoesLance);

                await _imovelRepository.Update(imovel);
                return "Veículo atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar veículo: {ex.Message}";
            }
        }

        public async Task<string> RemoveImovel(int id)
        {
            var imovel = await _imovelRepository.GetById(id);
            
            if (imovel == null) return "Imóvel não encontrado.";
            
            if (imovel.StatusPropriedade.Id != 1)
                return "Apenas Imóveis com status disponível podem ser removidos.";
            
            try
            {
                await _imovelRepository.Remove(imovel.Id);
                return "Imóvel removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover imóvel: {ex.Message}";
            }
        }

        public async Task<Imovel?> GetImovelById(int id)
        {
            return await _imovelRepository.GetById(id);
        }

        public async Task<List<Imovel>> GetAllImoveis()
        {
            return await _imovelRepository.GetAll();
        }

        public async Task<List<Imovel>> GetImoveisByLeilao(int leilaoId)
        {
            return await _imovelRepository.GetByLeilao(leilaoId);
        }

        public async Task<List<Imovel>> GetImoveisByStatus(int statusId)
        {
            return await _imovelRepository.GetByStatus(statusId);
        }
    }
}