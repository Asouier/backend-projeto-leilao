using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITipoVeiculoRepository
    {
        Task Add(TipoVeiculo tipoVeiculo);
        Task Update(TipoVeiculo tipoVeiculo);
        Task Remove(int id);
        Task<TipoVeiculo?> GetById(int id);
        Task<List<TipoVeiculo>> GetAll();
    }
}
