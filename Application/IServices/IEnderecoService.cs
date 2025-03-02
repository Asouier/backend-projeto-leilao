using Application.DTOs.Enderecos;
using Domain.Entities;

namespace Application.IServices
{
    public interface IEnderecoService
    {
        Task<Endereco?> GetEnderecoById(int id);
        Task<List<Endereco>> GetAllEnderecos();
        Task<List<Endereco>> GetEnderecosByCep(string cep);
        Task<List<Endereco>> GetEnderecosByCidade(string cidade);
        Task<string> AddEndereco(AddEnderecoDto endereco);
        Task<string> UpdateEndereco(UpdateEnderecoDto endereco);
        Task<string> RemoveEndereco(int id);
    }
}