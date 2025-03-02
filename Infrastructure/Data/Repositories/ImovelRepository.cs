using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly AppDbContext _context;

        public ImovelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Imovel imovel)
        {
            await _context.Imoveis.AddAsync(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Imovel imovel)
        {
            _context.Imoveis.Update(imovel);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel != null)
            {
                _context.Imoveis.Remove(imovel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Imovel?> GetById(int id)
        {
            return await _context.Imoveis.FindAsync(id);
        }

        public async Task<List<Imovel>> GetAll()
        {
            return await _context.Imoveis.ToListAsync();
        }

        public async Task<List<Imovel>> GetByLeilao(int leilaoId)
        {
            return await _context.Imoveis.Where(i => i.LeilaoId == leilaoId).ToListAsync();
        }

        public async Task<List<Imovel>> GetByStatus(int statusId)
        {
            return await _context.Imoveis.Where(i => i.StatusPropriedadeId == statusId).ToListAsync();
        }
    }
}