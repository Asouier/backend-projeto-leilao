using Application.DTOs.StatusLeiloes;
using Domain.Entities;

namespace Application.IServices
{
    public interface IStatusLeilaoService
    {
        Task<StatusLeilao?> GetStatusLeilaoById(int id);
        Task<List<StatusLeilao>> GetAllStatusLeiloes();
        Task<string> AddStatusLeilao(string statusLeilao);
        Task<string> UpdateStatusLeilao(UpdateStatusLeilaoDto statusLeilao);
        Task<string> RemoveStatusLeilao(int id);
    }
}