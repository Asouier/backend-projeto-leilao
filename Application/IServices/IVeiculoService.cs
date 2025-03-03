using Application.DTOs.Veiculos;
using Domain.Entities;

namespace Application.IServices
{
    public interface IVeiculoService
    {
        Task<Veiculo?> GetVeiculoById(int id);
        Task<List<Veiculo>> GetAllVeiculos();
        Task<List<Veiculo>> GetVeiculosByLeilao(int leilaoId);
        Task<List<Veiculo>> GetVeiculosByStatus(int statusId);
        Task<string> AddVeiculo(AddVeiculoDto veiculo);
        Task<string> UpdateVeiculo(UpdateVeiculoDto veiculo);
        Task<string> NovoLance(NovoLanceVeiculoDto informacoesLance);
        Task<string> RemoveVeiculo(int id);
    }
}