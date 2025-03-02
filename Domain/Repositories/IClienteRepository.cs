using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Remove(int id);
        Task<Cliente?> GetById(int id);
        Task<List<Cliente>> GetAll();
        Task<List<Cliente>?> GetByNome(string nome);
        Task<List<Cliente>?> GetByCpf(string cpf);
        Task<List<Cliente>?> GetByCnpj(string cnpj);
    }
}
