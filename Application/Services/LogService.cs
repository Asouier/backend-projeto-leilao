using Application.DTOs.Logs;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class LogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task<string> AddLog(AddLogDto novoLog)
        {
            try
            {
                var log = new Log
                {
                    UsuarioId = novoLog.UsuarioId,
                    ClienteId = novoLog.ClienteId,
                    LeilaoId = novoLog.LeilaoId,
                    Entidade = novoLog.Entidade,
                    EntidadeId = novoLog.EntidadeId,
                    Acao = novoLog.Acao,
                    DataHora = DateTime.UtcNow
                };

                await _logRepository.Add(log);
                return "Log adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Erro ao adicionar log: {ex.Message}";
            }
        }

        public async Task<List<Log>> GetAllLogs()
        {
            return await _logRepository.GetAll();
        }

        public async Task<List<Log>> GetLogsByUsuario(int usuarioId)
        {
            return await _logRepository.GetByUsuario(usuarioId);
        }

        public async Task<List<Log>> GetLogsByEntidade(string entidade)
        {
            return await _logRepository.GetByEntidade(entidade);
        }

        public async Task<List<Log>> GetLogsByAcao(string acao)
        {
            return await _logRepository.GetByAcao(acao);
        }
    }
}