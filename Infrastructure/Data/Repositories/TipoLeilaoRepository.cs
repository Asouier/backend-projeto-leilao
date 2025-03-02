using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TipoLeilaoRepository : ITipoLeilaoRepository
    {
        private readonly AppDbContext _context;

        public TipoLeilaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TipoLeilao tipoLeilao)
        {
            await _context.TiposLeilao.AddAsync(tipoLeilao);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoLeilao> AddAndReturn(TipoLeilao tipoLeilao)
        {
            await _context.TiposLeilao.AddAsync(tipoLeilao);
            await _context.SaveChangesAsync();
            return tipoLeilao;
        }

        public async Task Update(TipoLeilao tipoLeilao)
        {
            _context.TiposLeilao.Update(tipoLeilao);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var tipoLeilao = await _context.TiposLeilao.FindAsync(id);
            if (tipoLeilao != null)
            {
                _context.TiposLeilao.Remove(tipoLeilao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TipoLeilao?> GetById(int id)
        {
            return await _context.TiposLeilao.FindAsync(id);
        }

        public async Task<List<TipoLeilao>> GetAll()
        {
            return await _context.TiposLeilao.ToListAsync();
        }
    }
}