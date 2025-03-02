using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class StatusLeilaoRepository : IStatusLeilaoRepository
    {
        private readonly AppDbContext _context;

        public StatusLeilaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(StatusLeilao statusLeilao)
        {
            await _context.StatusLeiloes.AddAsync(statusLeilao);
            await _context.SaveChangesAsync();
        }

        public async Task Update(StatusLeilao statusLeilao)
        {
            _context.StatusLeiloes.Update(statusLeilao);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var statusLeilao = await _context.StatusLeiloes.FindAsync(id);
            if (statusLeilao != null)
            {
                _context.StatusLeiloes.Remove(statusLeilao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<StatusLeilao?> GetById(int id)
        {
            return await _context.StatusLeiloes.FindAsync(id);
        }

        public async Task<List<StatusLeilao>> GetAll()
        {
            return await _context.StatusLeiloes.ToListAsync();
        }
    }
}