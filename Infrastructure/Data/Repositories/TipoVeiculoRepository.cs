using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TipoVeiculoRepository : ITipoVeiculoRepository
    {
        private readonly AppDbContext _context;

        public TipoVeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TipoVeiculo tipoVeiculo)
        {
            await _context.TiposVeiculo.AddAsync(tipoVeiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TipoVeiculo tipoVeiculo)
        {
            _context.TiposVeiculo.Update(tipoVeiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var tipoVeiculo = await _context.TiposVeiculo.FindAsync(id);
            if (tipoVeiculo != null)
            {
                _context.TiposVeiculo.Remove(tipoVeiculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TipoVeiculo?> GetById(int id)
        {
            return await _context.TiposVeiculo.FindAsync(id);
        }

        public async Task<List<TipoVeiculo>> GetAll()
        {
            return await _context.TiposVeiculo.ToListAsync();
        }
    }
}