using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TipoImovelRepository : ITipoImovelRepository
    {
        private readonly AppDbContext _context;

        public TipoImovelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TipoImovel tipoImovel)
        {
            await _context.TiposImovel.AddAsync(tipoImovel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TipoImovel tipoImovel)
        {
            _context.TiposImovel.Update(tipoImovel);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var tipoImovel = await _context.TiposImovel.FindAsync(id);
            if (tipoImovel != null)
            {
                _context.TiposImovel.Remove(tipoImovel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TipoImovel?> GetById(int id)
        {
            return await _context.TiposImovel.FindAsync(id);
        }

        public async Task<List<TipoImovel>> GetAll()
        {
            return await _context.TiposImovel.ToListAsync();
        }
    }
}