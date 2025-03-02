using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICredencialRepository
    {
        Task Add(Credencial credencial);
        Task Update(Credencial credencial);
        Task Remove(int id);
        Task<Credencial?> GetById(int id);
        Task<Credencial?> GetByNomeUsuario(string nomeUsuario);
    }
}
