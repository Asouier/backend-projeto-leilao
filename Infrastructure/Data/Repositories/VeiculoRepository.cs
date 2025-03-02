using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly AppDbContext _context;

        public VeiculoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Veiculo veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Veiculo?> GetById(int id)
        {
            return await _context.Veiculos.FindAsync(id);
        }

        public async Task<List<Veiculo>> GetAll()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task<List<Veiculo>> GetByLeilao(int leilaoId)
        {
            return await _context.Veiculos.Where(v => v.LeilaoId == leilaoId).ToListAsync();
        }

        public async Task<List<Veiculo>> GetByStatus(int statusId)
        {
            return await _context.Veiculos.Where(v => v.StatusPropriedadeId == statusId).ToListAsync();
        }
    }
}