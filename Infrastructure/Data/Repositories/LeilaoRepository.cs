using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Persistence;

namespace Infrastructure.Data.Repositories
{
    public class LeilaoRepository : ILeilaoRepository
    {
        private readonly AppDbContext _context;

        public LeilaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Leilao leilao)
        {
            await _context.Leiloes.AddAsync(leilao);
            await _context.SaveChangesAsync();
            return leilao.Id;
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
                leilao.StatusId = 3; // "Encerrado"; // Supondo que "Encerrado" é um status válido
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Leilao?> GetById(int id)
        {
            return await _context.Leiloes.FindAsync(id);
        }

        public async Task<List<Leilao>> GetAll()
        {
            return await _context.Leiloes
                .Include(l => l.TipoLeilao)          // Inclui o TipoLeilao
                .Include(l => l.Imoveis)              // Inclui a coleção de Imoveis
                .Include(l => l.Veiculos)             // Inclui a coleção de Veiculos
                .Include(l => l.Status)               // Inclui o Status
                .Include(l => l.Endereco)             // Inclui o Endereco
                .Include(l => l.UsuarioCadastro)      // Inclui o UsuarioCadastro
                .Include(l => l.UsuarioAprovacao)     // Inclui o UsuarioAprovacao
                .ToListAsync();
        }

        public async Task<List<Leilao>> GetByStatus(int statusId)
        {
            return await _context.Leiloes.Where(l => l.StatusId == statusId).ToListAsync();
        }

        public async Task<List<Leilao>> GetByTipoLeilao(int tipoLeilaoId)
        {
            return await _context.Leiloes.Where(l => l.TipoLeilaoId == tipoLeilaoId).ToListAsync();
        }
    }
}