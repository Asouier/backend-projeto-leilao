using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICredencialRepository
    {
        Task Add(Credencial credencial);
        Task Update(Credencial credencial);
        Task Remove(string id);
        Task<Credencial> GetById(string id);
        Task<List<Credencial>> GetAll();
        Task<Credencial> GetByNomeUsuario(string nomeUsuario);
    }
}
