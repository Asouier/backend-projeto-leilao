using Domain.Entities;

namespace Domain.Repositories
{
    public interface ILogRepository
    {
        Task Add(Log log);
        Task<List<Log>> GetAll();
        Task<List<Log>> GetByUsuario(int usuarioId);
        Task<List<Log>> GetByEntidade(string entidade);
        Task<List<Log>> GetByAcao(string acao);
    }
}
