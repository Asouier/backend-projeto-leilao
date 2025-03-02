using Application.DTOs.TipoImoveis;
using Domain.Entities;

namespace Application.IServices
{
    public interface ITipoImovelService
    {
        Task<TipoImovel?> GetTipoImovelById(int id);
        Task<List<TipoImovel>> GetAllTipoImoveis();
        Task<string> AddTipoImovel(string tipoImovel);
        Task<string> UpdateTipoImovel(UpdateTipoImovelDto tipoImovel);
        Task<string> RemoveTipoImovel(int id);
    }
}