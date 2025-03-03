using Application.DTOs.TipoVeiculos;
using Application.IServices;
using Domain.Entities;
using Domain.Extensions;
using Domain.Repositories;

namespace Application.Services
{
    public class TipoVeiculoService: ITipoVeiculoService
    {
        private readonly ITipoVeiculoRepository _tipoVeiculoRepository;

        public TipoVeiculoService(ITipoVeiculoRepository tipoVeiculoRepository)
        {
            _tipoVeiculoRepository = tipoVeiculoRepository;
        }

        public async Task<string> AddTipoVeiculo(string novoTipoVeiculo)
        {
            try
            {
                var tipoVeiculo = TipoVeiculo.Create(novoTipoVeiculo);

                await _tipoVeiculoRepository.Add(tipoVeiculo);
                return "Tipo de veículo adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar tipo de veículo: {ex.Message}";
            }
        }

        public async Task<string> UpdateTipoVeiculo(UpdateTipoVeiculoDto novosDados)
        {
            try
            {
                var tipoVeiculo = await _tipoVeiculoRepository.GetById(novosDados.Id);
                if (tipoVeiculo == null)
                {
                    return "Tipo de veículo não encontrado.";
                }

                tipoVeiculo.AtualizarPropriedadesNaoNulas(novosDados);

                await _tipoVeiculoRepository.Update(tipoVeiculo);
                return "Tipo de veículo atualizado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao atualizar tipo de veículo: {ex.Message}";
            }
        }

        public async Task<string> RemoveTipoVeiculo(int id)
        {
            try
            {
                var tipoVeiculo = await _tipoVeiculoRepository.GetById(id);
                if (tipoVeiculo == null)
                {
                    return "Tipo de veículo não encontrado.";
                }

                await _tipoVeiculoRepository.Remove(tipoVeiculo.Id);
                return "Tipo de veículo removido com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao remover tipo de veículo: {ex.Message}";
            }
        }

        public async Task<TipoVeiculo?> GetTipoVeiculoById(int id)
        {
            return await _tipoVeiculoRepository.GetById(id);
        }

        public async Task<List<TipoVeiculo>> GetAllTipoVeiculos()
        {
            return await _tipoVeiculoRepository.GetAll();
        }
    }
}