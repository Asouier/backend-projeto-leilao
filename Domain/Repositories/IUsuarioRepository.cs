using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Remove(int id);
        Task<Usuario?> GetById(int id);
        Task<List<Usuario>> GetAll();
        Task<Usuario?> GetByCpf(string cpf);
        Task<List<Usuario>> GetByCargo(string cargo);
    }
}
