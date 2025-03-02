using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Infrastructure.Data.Repositories
{
    public class CredencialRepository : ICredencialRepository
    {
        private readonly AppDbContext _context;

        public CredencialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Credencial credencial)
        {
            await _context.Credenciais.AddAsync(credencial);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Credencial credencial)
        {
            _context.Credenciais.Update(credencial);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var credencial = await _context.Credenciais.FindAsync(id);
            if (credencial != null)
            {
                _context.Credenciais.Remove(credencial);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Credencial?> GetById(int id)
        {
            return await _context.Credenciais.FindAsync(id);
        }

        public async Task<List<Credencial>> GetAll()
        {
            return await _context.Credenciais.ToListAsync();
        }

        public async Task<Credencial?> GetByNomeUsuario(string nomeUsuario)
        {
            return await _context.Credenciais.FirstOrDefaultAsync(c => c.NomeUsuario == nomeUsuario);
        }
    }
}