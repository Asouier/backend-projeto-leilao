using Domain.Entities;
namespace Domain.Repositories
{
    public interface IImovelRepository
    {
        Task Add(Imovel imovel);
        Task Update(Imovel imovel);
        Task Remove(int id);
        Task<Imovel?> GetById(int id);
        Task<List<Imovel>> GetAll();
        Task<List<Imovel>> GetByLeilao(int leilaoId);
        Task<List<Imovel>> GetByStatus(int statusId);
    }
}
