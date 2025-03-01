using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IStatusLeilaoRepository
    {
        Task Add(StatusLeilao statusLeilao);
        Task Update(StatusLeilao statusLeilao);
        Task Remove(int id);
        Task<StatusLeilao> GetById(int id);
        Task<List<StatusLeilao>> GetAll();
    }
}
