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
        Task Remove(string id);
        Task<StatusLeilao> GetById(string id);
        Task<List<StatusLeilao>> GetAll();
    }
}
