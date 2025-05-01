using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class PilarCompetenciaRepository : IPilarCompetenciaRepository
    {
        private readonly PeopleFirstDbContext _context;

        public PilarCompetenciaRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PilarCompetencia>> GetAllAsync()
        {
            return await _context.PilaresCompetencia
                .Include(p => p.Perfil)
                .Include(p => p.TipoCompetencia)
                .ToListAsync();
        }

        public async Task<PilarCompetencia?> GetByIdAsync(int id)
        {
            return await _context.PilaresCompetencia
                .Include(p => p.Perfil)
                .Include(p => p.TipoCompetencia)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(PilarCompetencia pilar)
        {
            await _context.PilaresCompetencia.AddAsync(pilar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PilarCompetencia pilar)
        {
            _context.PilaresCompetencia.Update(pilar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pilar = await _context.PilaresCompetencia.FindAsync(id);
            if (pilar != null)
            {
                _context.PilaresCompetencia.Remove(pilar);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.PilaresCompetencia.CountAsync();
        }

        public async Task<IEnumerable<PilarCompetencia>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.PilaresCompetencia
                                 .OrderBy(p => p.Pilar)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
