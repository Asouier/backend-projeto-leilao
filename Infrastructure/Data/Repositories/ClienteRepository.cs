using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cliente?> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<List<Cliente>?> GetByNome(string nome)
        {
            return await _context.Clientes
        .Where(c => c.NomeCompleto != null && c.NomeCompleto.Contains(nome))
        .ToListAsync();
        }

        public async Task<List<Cliente>?> GetByCpf(string cpf)
        {
            return await _context.Clientes.Where(c => c.Cpf == cpf).ToListAsync();
        }

        public async Task<List<Cliente>?> GetByCnpj(string cnpj)
        {
            return await _context.Clientes.Where(c => c.Cnpj == cnpj).ToListAsync();
        }
    }
}