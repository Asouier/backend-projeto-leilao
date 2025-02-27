using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IContatoRepository
    {
        Task Add(Contato contato);
        Task Update(Contato contato);
        Task Remove(string id);
        Task<Contato> GetById(string id);
        Task<List<Contato>> GetAll();
        Task<Contato> GetByEmail(string email);
        Task<List<Contato>> GetByTelefone(string telefone);
    }
}
