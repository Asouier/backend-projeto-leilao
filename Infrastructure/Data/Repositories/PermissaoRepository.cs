using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private readonly AppDbContext _context;

        public PermissaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Permissao permissao)
        {
            await _context.Permissoes.AddAsync(permissao);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Permissao permissao)
        {
            _context.Permissoes.Update(permissao);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var permissao = await _context.Permissoes.FindAsync(id);
            if (permissao != null)
            {
                _context.Permissoes.Remove(permissao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Permissao?> GetById(int id)
        {
            return await _context.Permissoes.FindAsync(id);
        }

        public async Task<List<Permissao>> GetAll()
        {
            return await _context.Permissoes.ToListAsync();
        }
    }
}