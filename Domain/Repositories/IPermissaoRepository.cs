using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IPermissaoRepository
    {
        Task Add(Permissao permissao);
        Task Update(Permissao permissao);
        Task Remove(string id);
        Task<Permissao> GetById(string id);
        Task<List<Permissao>> GetAll();
    }
}
