using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly AppDbContext _context;

        public ContatoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Contato contato)
        {
            await _context.Contatos.AddAsync(contato);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Contato contato)
        {
            _context.Contatos.Update(contato);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Contato> GetById(int id)
        {
            return await _context.Contatos.FindAsync(id);
        }

        public async Task<List<Contato>> GetAll()
        {
            return await _context.Contatos.ToListAsync();
        }

        public async Task<Contato> GetByEmail(string email)
        {
            return await _context.Contatos.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<List<Contato>> GetByTelefone(string telefone)
        {
            return await _context.Contatos.Where(c => c.Telefone == telefone).ToListAsync();
        }
    }
}