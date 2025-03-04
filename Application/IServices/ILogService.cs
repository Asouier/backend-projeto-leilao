using Application.DTOs.Logs;
using Domain.Entities;
namespace Application.IServices
{
    public interface ILogService
    {
        Task<string> AddLog(AddLogDto novoLog);
        Task<List<Log>> GetAllLogs();
        Task<List<Log>> GetLogsByUsuario(int usuarioId);
        Task<List<Log>> GetLogsByEntidade(string entidade);
        Task<List<Log>> GetLogLances(int leilaoId, int entidadeId);
        Task<List<Log>> GetLogsByAcao(string acao);
    }
}
