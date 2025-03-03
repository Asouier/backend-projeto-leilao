using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Persistence;

namespace Infrastructure.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Endereco?> GetById(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<List<Endereco>> GetAll()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<List<Endereco>> GetByCep(string cep)
        {
            return await _context.Enderecos.Where(e => e.Cep == cep).ToListAsync();
        }

        public async Task<List<Endereco>> GetByCidade(string cidade)
        {
            return await _context.Enderecos.Where(e => e.Cidade == cidade).ToListAsync();
        }
    }
}