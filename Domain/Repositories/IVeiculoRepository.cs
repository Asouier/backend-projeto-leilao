using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVeiculoRepository
    {
        Task Add(Veiculo veiculo);
        Task Update(Veiculo veiculo);
        Task Remove(int id);
        Task<Veiculo?> GetById(int id);
        Task<List<Veiculo>> GetAll();
        Task<List<Veiculo>> GetByLeilao(int leilaoId);
        Task<List<Veiculo>> GetByStatus(int statusId);
    }
}
