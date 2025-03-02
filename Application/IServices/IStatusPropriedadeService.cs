using Application.DTOs.StatusPropriedades;
using Domain.Entities;

namespace Application.IServices
{
    public interface IStatusPropriedadeService
    {
        Task<StatusPropriedade?> GetStatusPropriedadeById(int id);
        Task<List<StatusPropriedade>> GetAllStatusPropriedades();
        Task<string> AddStatusPropriedade(string statusPropriedade);
        Task<string> UpdateStatusPropriedade(UpdateStatusPropriedadeDto statusPropriedade);
        Task<string> RemoveStatusPropriedade(int id);
    }
}