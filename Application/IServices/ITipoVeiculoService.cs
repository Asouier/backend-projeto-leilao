using Application.DTOs.TipoVeiculos;
using Domain.Entities;

namespace Application.IServices
{
    public interface ITipoVeiculoService
    {
        Task<TipoVeiculo?> GetTipoVeiculoById(int id);
        Task<List<TipoVeiculo>> GetAllTipoVeiculos();
        Task<string> AddTipoVeiculo(string tipoVeiculo);
        Task<string> UpdateTipoVeiculo(UpdateTipoVeiculoDto tipoVeiculo);
        Task<string> RemoveTipoVeiculo(int id);
    }
}