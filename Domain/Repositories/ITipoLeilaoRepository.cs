using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITipoLeilaoRepository
    {
        Task Add(TipoLeilao tipoLeilao);
        Task Update(TipoLeilao tipoLeilao);
        Task Remove(int id);
        Task<TipoLeilao?> GetById(int id);
        Task<List<TipoLeilao>> GetAll();
    }
}
