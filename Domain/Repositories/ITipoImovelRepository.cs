using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ITipoImovelRepository
    {
        Task Add(TipoImovel tipoImovel);
        Task Update(TipoImovel tipoImovel);
        Task Remove(int id);
        Task<TipoImovel> GetById(int id);
        Task<List<TipoImovel>> GetAll();
    }
}
