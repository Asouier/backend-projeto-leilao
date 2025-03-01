using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStatusPropriedadeRepository
    {
        Task Add(StatusPropriedade statusPropriedade);
        Task Update(StatusPropriedade statusPropriedade);
        Task Remove(int id);
        Task<StatusPropriedade> GetById(int id);
        Task<List<StatusPropriedade>> GetAll();
    }
}
