using Domain.Entities;

namespace Domain.Repositories
{
    public interface IContatoRepository
    {
        Task Add(Contato contato);
        Task Update(Contato contato);
        Task Remove(int id);
        Task<Contato?> GetById(int id);
        Task<List<Contato>> GetAll();
        Task<Contato?> GetByEmail(string email);
    }
}
