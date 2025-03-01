using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITipoLeilaoRepository
    {
        Task Add(TipoLeilao tipoLeilao);
        Task Update(TipoLeilao tipoLeilao);
        Task Remove(int id);
        Task<TipoLeilao> GetById(int id);
        Task<List<TipoLeilao>> GetAll();
    }
}
