using Domain.Entities;
using Domain.Repositories;

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

        public async Task Remove(string id)
        {
            var imovel = await _context.Imoveis.FindAsync(id);
            if (imovel != null)
            {
                _context.Imoveis.Remove(imovel);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Imovel> GetById(string id)
        {
            return await _context.Imoveis.FindAsync(id);
        }

        public async Task<List<Imovel>> GetAll()
        {
            return await _context.Imoveis.ToListAsync();
        }

        public async Task<List<Imovel>> GetByLeilao(string leilaoId)
        {
            return await _context.Imoveis.Where(i => i.LeilaoId == leilaoId).ToListAsync();
        }

        public async Task<List<Imovel>> GetByStatus(string status)
        {
            return await _context.Imoveis.Where(i => i.StatusPropriedadeId == status).ToListAsync();
        }
    }
}