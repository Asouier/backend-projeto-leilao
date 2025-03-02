using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepresentanteLegalRepository
    {
        Task Add(RepresentanteLegal representanteLegal);
        Task Update(RepresentanteLegal representanteLegal);
        Task Remove(int id);
        Task<RepresentanteLegal?> GetById(int id);
        Task<RepresentanteLegal?> GetByCpf(string cpf);
    }
}