using Application.DTOs.Imoveis;
using Application.Models.Imoveis;
using Domain.Entities;

namespace Application.IServices
{
    public interface IImovelService
    {
        Task<Imovel?> GetImovelById(int id);
        Task<List<Imovel>> GetAllImoveis();
        Task<List<Imovel>> GetImoveisByLeilao(int leilaoId);
        Task<List<Imovel>> GetImoveisByStatus(int statusId);
        Task<string> AddImovel(AddImovelDto imovel);
        Task<string> UpdateImovel(UpdateImovelDto imovel);
        Task<string> NovoLance(NovoLanceImovelDto informacoesLance);
        Task<string> RemoveImovel(int id);
    }
}