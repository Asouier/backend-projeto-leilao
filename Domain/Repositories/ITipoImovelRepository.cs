using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITipoImovelRepository
    {
        Task Add(TipoImovel tipoImovel);
        Task Update(TipoImovel tipoImovel);
        Task Remove(int id);
        Task<TipoImovel?> GetById(int id);
        Task<List<TipoImovel>> GetAll();
    }
}
