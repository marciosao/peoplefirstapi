using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class TimeColaboradorRepository : ITimeColaboradorRepository
    {
        private readonly PeopleFirstDbContext _context;

        public TimeColaboradorRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeColaborador>> GetAllAsync()
        {
            return await _context.TimesColaboradores
                .Include(t => t.Time)
                .Include(t => t.Colaborador)
                .ToListAsync();
        }

        public async Task<TimeColaborador?> GetByIdAsync(int id)
        {
            return await _context.TimesColaboradores
                .Include(t => t.Time)
                .Include(t => t.Colaborador)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TimeColaborador item)
        {
            await _context.TimesColaboradores.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TimeColaborador item)
        {
            _context.TimesColaboradores.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.TimesColaboradores.FindAsync(id);
            if (item != null)
            {
                _context.TimesColaboradores.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
