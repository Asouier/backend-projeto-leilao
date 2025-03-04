using Application.DTOs.Logs;
using Application.IServices;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class LogService: ILogService
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
        public async Task<List<Log>> GetLogLances(int leilaoId, int entidadeId)
        {
            return await _logRepository.GetByIdLeilaoAndIdEntidade(leilaoId, entidadeId);
        }

        public async Task<List<Log>> GetLogsByAcao(string acao)
        {
            return await _logRepository.GetByAcao(acao);
        }
    }
}