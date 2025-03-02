using Domain.Entities;

namespace Domain.Repositories
{
    public interface IStatusLeilaoRepository
    {
        Task Add(StatusLeilao statusLeilao);
        Task Update(StatusLeilao statusLeilao);
        Task Remove(int id);
        Task<StatusLeilao?> GetById(int id);
        Task<List<StatusLeilao>> GetAll();
    }
}
