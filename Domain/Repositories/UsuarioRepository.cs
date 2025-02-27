using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface UsuarioRepository
    {
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Remove(string id);
        Task<Usuario> GetById(string id);
        Task<List<Usuario>> GetAll();
        Task<Usuario> GetByCpf(string cpf);
        Task<List<Usuario>> GetByCargo(string cargo);
    }
}
