using Application.DTOs.Leiloes;
using Domain.Entities;

namespace Application.IServices
{
    public interface ILeilaoService
    {
        Task<Leilao?> GetLeilaoById(int id);
        Task<List<Leilao>> GetAllLeiloes();
        Task<List<Leilao>> GetByStatus(int statusId);
        Task<List<Leilao>> GetByTipoLeilao(int tipoLeilaoId);
        Task<string> AddLeilao(AddLeilaoDto leilao);
        Task<string> UpdateLeilao(UpdateLeilaoDto leilao);
    }
}