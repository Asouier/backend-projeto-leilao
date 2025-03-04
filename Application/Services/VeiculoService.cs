using Application.DTOs.Veiculos;
using Application.IServices;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class VeiculoService: IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ILeilaoRepository _leilaoRepository;
        private readonly ILogRepository _logRepository;
        private readonly AppDbContext _context;

        public VeiculoService(IVeiculoRepository veiculoRepository, ILeilaoRepository leilaoRepository, ILogRepository logRepository, AppDbContext context)
        {
            _veiculoRepository = veiculoRepository;
            _leilaoRepository = leilaoRepository;
            _logRepository = logRepository;
            _context = context;
        }

        // Adiciona um novo veículo
        public async Task<string> AddVeiculo(AddVeiculoDto novoVeiculo)
        {
            try
            {
                var veiculo = new Veiculo
                {
                    LeilaoId = novoVeiculo.LeilaoId,
                    TipoVeiculoId = novoVeiculo.TipoVeiculoId,
                    Placa = novoVeiculo.Placa,
                    Chassi = novoVeiculo.Chassi,
                    Marca = novoVeiculo.Marca,
                    Modelo = novoVeiculo.Modelo,
                    AnoFabricacao = novoVeiculo.AnoFabricacao,
                    Cor = novoVeiculo.Cor,
                    ValorMinimo = novoVeiculo.ValorMinimo,
                    StatusPropriedadeId = novoVeiculo.StatusPropriedadeId,
                    UsuarioCadastroId = novoVeiculo.UsuarioCadastroId,
                    DataRecolhimento = novoVeiculo.DataRecolhimento,
                    MotivoRecolhimento = novoVeiculo.MotivoRecolhimento
                };

                await _veiculoRepository.Add(veiculo);
                return "Veículo adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar veículo: {ex.Message}";
            }
        }

        public async Task<string> UpdateVeiculo(UpdateVeiculoDto novosDados)
        {
            try
            {
                var veiculo = await _veiculoRepository.GetById(novosDados.Id);
                if (veiculo == null)
                {
                    return "Veículo não encontrado.";
                }

                var anfitriao = await _leilaoRepository.GetById(veiculo.LeilaoId);
                if (anfitriao == null) return "O leilão indicado não existe ou não está disponível";

                veiculo.AtualizarPropriedadesNaoNulas(novosDados);

                await _veiculoRepository.Update(veiculo);
                return "Veículo atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar veículo: {ex.Message}";
            }
        }
        public async Task<string> NovoLance(NovoLanceVeiculoDto informacoesLance)
        {
            var executionStrategy = _context.Database.CreateExecutionStrategy();

            return await executionStrategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var veiculo = await _veiculoRepository.GetById(informacoesLance.IdVeiculo);
                    if (veiculo == null)
                    {
                        return "Veículo não encontrado.";
                    }

                    var anfitriao = await _leilaoRepository.GetById(veiculo.LeilaoId);
                    if (anfitriao == null) return "O leilão indicado não existe ou não está disponível";
                    if (anfitriao.StatusId != 1) // Trocar para um enum
                    {
                        return "O Leilão anfitrião não esta mais disponivel, logo não haverão mudanças nas informações do Veiculo";
                    }

                    if (informacoesLance.ValorMinimo < veiculo.ValorMinimo)
                    {
                        return "Esse tipo de alteração viola a política de uso do Leilão. Um representante do Leilão entrará em contato com você em breve.";
                        //Adicionar log
                    }

                    veiculo.AtualizarPropriedadesNaoNulas(informacoesLance);
                    var log = new Log
                    {
                        ClienteId = informacoesLance.ClienteArrematanteId,
                        LeilaoId = veiculo.LeilaoId,
                        Entidade = "Veículo",
                        EntidadeId = informacoesLance.IdVeiculo,
                        Acao = $"Novo Lance(R${informacoesLance.ValorMinimo})",
                        DataHora = DateTime.UtcNow
                    };

                    await _veiculoRepository.Update(veiculo);
                    await _logRepository.Add(log);

                    await transaction.CommitAsync();
                    return "Novo lance atribuido.";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    var innerExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : "Nenhuma exceção interna.";
                    return $"Erro ao adicionar leilão: {ex.Message}; Exceção interna: {innerExceptionMessage}";
                }
            });
        }

        public async Task<string> RemoveVeiculo(int id)
        {
            var veiculo = await _veiculoRepository.GetById(id);
            
            if (veiculo == null) return "Veículo não encontrado.";
            
            if (veiculo.StatusPropriedade.Id != 1)
                return "Apenas Imóveis com status disponível podem ser removidos.";
            
            try
            {
                await _veiculoRepository.Remove(veiculo.Id);
                return "Veículo removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover veículo: {ex.Message}";
            }
        }

        public async Task<Veiculo?> GetVeiculoById(int id)
        {
            return await _veiculoRepository.GetById(id);
        }

        public async Task<List<Veiculo>> GetAllVeiculos()
        {
            return await _veiculoRepository.GetAll();
        }

        public async Task<List<Veiculo>> GetVeiculosByLeilao(int leilaoId)
        {
            return await _veiculoRepository.GetByLeilao(leilaoId);
        }

        public async Task<List<Veiculo>> GetVeiculosByStatus(int statusId)
        {
            return await _veiculoRepository.GetByStatus(statusId);
        }
    }
}