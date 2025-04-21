using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class TipoCompetenciaRepository : ITipoCompetenciaRepository
    {
        private readonly PeopleFirstDbContext _context;

        public TipoCompetenciaRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoCompetencia>> GetAllAsync()
        {
            return await _context.TiposCompetencia.ToListAsync();
        }

        public async Task<TipoCompetencia?> GetByIdAsync(int id)
        {
            return await _context.TiposCompetencia.FindAsync(id);
        }

        public async Task AddAsync(TipoCompetencia tipo)
        {
            await _context.TiposCompetencia.AddAsync(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoCompetencia tipo)
        {
            _context.TiposCompetencia.Update(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipo = await _context.TiposCompetencia.FindAsync(id);
            if (tipo != null)
            {
                _context.TiposCompetencia.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
