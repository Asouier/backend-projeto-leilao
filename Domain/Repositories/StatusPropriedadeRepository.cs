using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface StatusPropriedadeRepository
    {
        Task Add(StatusPropriedade statusPropriedade);
        Task Update(StatusPropriedade statusPropriedade);
        Task Remove(string id);
        Task<StatusPropriedade> GetById(string id);
        Task<List<StatusPropriedade>> GetAll();
    }
}
