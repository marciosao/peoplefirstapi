using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly PeopleFirstDbContext _context;

        public PerfilRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Perfil>> GetAllAsync()
        {
            return await _context.Perfis.ToListAsync();
        }

        public async Task<Perfil> GetByIdAsync(int id)
        {
            return await _context.Perfis.FindAsync(id);
        }

        public async Task AddAsync(Perfil perfil)
        {
            await _context.Perfis.AddAsync(perfil);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Perfil perfil)
        {
            _context.Perfis.Update(perfil);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var perfil = await _context.Perfis.FindAsync(id);
            if (perfil != null)
            {
                _context.Perfis.Remove(perfil);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.Perfis.CountAsync();
        }

        public async Task<IEnumerable<Perfil>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.Perfis
                                 .OrderBy(p => p.PerfilNome)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
