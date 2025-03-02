using Application.DTOs.Veiculos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Domain.Services
{
    public class VeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
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

                veiculo.AtualizarPropriedadesNaoNulas(novosDados);

                await _veiculoRepository.Update(veiculo);
                return "Veículo atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar veículo: {ex.Message}";
            }
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