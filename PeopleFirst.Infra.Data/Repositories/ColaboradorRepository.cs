using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly PeopleFirstDbContext _context;

        public ColaboradorRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Colaborador>> GetAllAsync()
        {
            return await _context.Colaboradores.Include(c => c.Perfil).ToListAsync();
        }

        public async Task<Colaborador?> GetByIdAsync(int id)
        {
            return await _context.Colaboradores.Include(c => c.Perfil)
                                               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Colaborador colaborador)
        {
            await _context.Colaboradores.AddAsync(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Colaborador colaborador)
        {
            _context.Colaboradores.Update(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var colaborador = await _context.Colaboradores.FindAsync(id);
            if (colaborador != null)
            {
                _context.Colaboradores.Remove(colaborador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
