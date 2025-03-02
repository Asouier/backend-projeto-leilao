using Infrastructure.Data.Repositores;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario?> GetById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<List<Usuario>> GetAll()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByCpf(string cpf)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Cpf == cpf);
        }

        public async Task<List<Usuario>> GetByCargo(string cargo)
        {
            return await _context.Usuarios.Where(u => u.CargoFuncao == cargo).ToListAsync();
        }
        public async Task<Usuario?> GetByCredencialId(int credencialId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(c => c.CredencialId == credencialId);
        }
    }
}