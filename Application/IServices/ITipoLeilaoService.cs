using Application.DTOs.TipoLeiloes;
using Domain.Entities;

namespace Application.IServices
{
    public interface ITipoLeilaoService
    {
        Task<TipoLeilao?> GetTipoLeilaoById(int id);
        Task<List<TipoLeilao>> GetAllTipoLeiloes();
        Task<string> AddTipoLeilao(string tipoLeilao);
        Task<string> UpdateTipoLeilao(UpdateTipoLeilaoDto tipoLeilao);
        Task<string> RemoveTipoLeilao(int id);
    }
}