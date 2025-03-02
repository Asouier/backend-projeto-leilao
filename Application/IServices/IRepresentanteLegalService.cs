using Application.DTOs.RepresentantesLegais;
using Domain.Entities;

namespace Application.IServices
{
    public interface IRepresentanteLegalService
    {
        Task<RepresentanteLegal?> GetRepresentanteLegalById(int id);
        Task<RepresentanteLegal?> GetRepresentanteLegalByCpf(string cpf);
        Task<string> AddRepresentanteLegal(AddRepresentanteLegalDto representanteLegal);
        Task<string> UpdateRepresentanteLegal(UpdateRepresentanteLegalDto representanteLegal);
        Task<string> RemoveRepresentanteLegal(int id);
    }
}