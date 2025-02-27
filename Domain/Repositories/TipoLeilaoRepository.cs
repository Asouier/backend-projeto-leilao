using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface TipoLeilaoRepository
    {
        Task Add(TipoLeilao tipoLeilao);
        Task Update(TipoLeilao tipoLeilao);
        Task Remove(string id);
        Task<TipoLeilao> GetById(string id);
        Task<List<TipoLeilao>> GetAll();
    }
}
