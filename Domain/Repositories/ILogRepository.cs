using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ILogRepository
    {
        Task Add(Log log);
        Task<List<Log>> GetAll();
        Task<List<Log>> GetByUsuario(string usuarioId);
        Task<List<Log>> GetByEntidade(string entidade);
        Task<List<Log>> GetByAcao(string acao);
    }
}
