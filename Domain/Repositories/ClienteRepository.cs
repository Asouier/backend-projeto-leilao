using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ClienteRepository
    {
        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Remove(string id);
        Task<Cliente> GetById(string id);
        Task<List<Cliente>> GetAll();
        Task<List<Cliente>> GetByNome(string nome);
        Task<List<Cliente>> GetByCpf(string cpf);
        Task<List<Cliente>> GetByCnpj(string cnpj);
    }
}
