using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class RepresentanteLegalRepository : IRepresentanteLegalRepository
    {
        private readonly AppDbContext _context;

        public RepresentanteLegalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(RepresentanteLegal representanteLegal)
        {
            await _context.RepresentantesLegais.AddAsync(representanteLegal);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RepresentanteLegal representanteLegal)
        {
            _context.RepresentantesLegais.Update(representanteLegal);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            var representanteLegal = await _context.RepresentantesLegais.FindAsync(id);
            if (representanteLegal != null)
            {
                _context.RepresentantesLegais.Remove(representanteLegal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RepresentanteLegal> GetById(string id)
        {
            return await _context.RepresentantesLegais.FindAsync(id);
        }

        public async Task<List<RepresentanteLegal>> GetAll()
        {
            return await _context.RepresentantesLegais.ToListAsync();
        }

        public async Task<RepresentanteLegal> GetByCpf(string cpf)
        {
            return await _context.RepresentantesLegais.FirstOrDefaultAsync(r => r.Cpf == cpf);
        }
    }
}