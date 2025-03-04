using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Persistence;

namespace Infrastructure.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly AppDbContext _context;

        public LogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Log log)
        {
            await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Log>> GetAll()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<List<Log>> GetByUsuario(int usuarioId)
        {
            return await _context.Logs.Where(l => l.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<List<Log>> GetByEntidade(string entidade)
        {
            return await _context.Logs.Where(l => l.Entidade == entidade).ToListAsync();
        }
        public async Task<List<Log>> GetByIdLeilaoAndIdEntidade(int leilaoId, int entidadeId)
        {
            return await _context.Logs.Where(l => l.EntidadeId == entidadeId && l.LeilaoId == leilaoId).ToListAsync();
        }
        public async Task<List<Log>> GetByAcao(string acao)
        {
            return await _context.Logs.Where(l => l.Acao == acao).ToListAsync();
        }
    }
}