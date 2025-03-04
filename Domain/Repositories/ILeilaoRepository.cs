using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILeilaoRepository
    {
        Task<int> Add(Leilao leilao);
        Task Update(Leilao leilao);
        Task<Leilao?> GetById(int id);
        Task<List<Leilao>> GetAll();
        Task<List<Leilao>> GetByStatus(int statusId);
        Task<List<Leilao>> GetByTipoLeilao(int tipoLeilaoId);
    }
}