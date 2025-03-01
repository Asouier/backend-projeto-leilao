using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class LeilaoRepository : ILeilaoRepository
    {
        private readonly AppDbContext _context;

        public LeilaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Leilao leilao)
        {
            await _context.Leiloes.AllAsync(leilao);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            await _context.SaveChangesAsync();
        }

        public async Task Close(int id)
        {
            var leilao = await _context.Leiloes.FindAsync(id);
            if (leilao != null)
            {
                leilao.StatusId = "Encerrado"; // Supondo que "Encerrado" é um status válido
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Leilao> GetById(int id)
        {
            return await _context.Leiloes.FindAsync(id);
        }

        public async Task<List<Leilao>> GetAll()
        {
            return await _context.Leiloes.ToListAsync();
        }

        public async Task<List<Leilao>> GetByStatus(string status)
        {
            return await _context.Leiloes.Where(l => l.StatusId == status).ToListAsync();
        }

        public async Task<List<Leilao>> GetByTipoLeilao(string tipoLeilaoId)
        {
            return await _context.Leiloes.Where(l => l.TipoLeilaoId == tipoLeilaoId).ToListAsync();
        }
    }
}