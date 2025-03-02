using Application.DTOs.Clientes;
using Domain.Entities;

namespace Application.IServices
{
    public interface IClienteService
    {
        Task<Cliente?> GetClienteById(int id);
        Task<List<Cliente>> GetAllClientes();
        Task<List<Cliente>> GetClienteByCredencialId(int credencialId);
        Task<List<Cliente>?> GetClientesByNome(string nome);
        Task<List<Cliente>?> GetClientesByCpf(string cpf);
        Task<List<Cliente>?> GetClientesByCnpj(string cnpj);
        Task<string> AddCliente(AddClienteDto cliente);
        Task<string> UpdateCliente(UpdateClienteDto cliente);
        Task<string> RemoveCliente(int id);
    }
}