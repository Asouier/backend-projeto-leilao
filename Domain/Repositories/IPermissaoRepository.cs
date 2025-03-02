using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPermissaoRepository
    {
        Task Add(Permissao permissao);
        Task<Permissao> AddAndReturn(Permissao permissao);
        Task Update(Permissao permissao);
        Task Remove(int id);
        Task<Permissao?> GetById(int id);
        Task<List<Permissao>> GetAll();
    }
}
