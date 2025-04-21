using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class PilarHappinessRepository : IPilarHappinessRepository
    {
        private readonly PeopleFirstDbContext _context;

        public PilarHappinessRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PilarHappiness>> GetAllAsync()
        {
            return await _context.PilaresHappiness.ToListAsync();
        }

        public async Task<PilarHappiness?> GetByIdAsync(int id)
        {
            return await _context.PilaresHappiness.FindAsync(id);
        }

        public async Task AddAsync(PilarHappiness pilar)
        {
            await _context.PilaresHappiness.AddAsync(pilar);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PilarHappiness pilar)
        {
            _context.PilaresHappiness.Update(pilar);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pilar = await _context.PilaresHappiness.FindAsync(id);
            if (pilar != null)
            {
                _context.PilaresHappiness.Remove(pilar);
                await _context.SaveChangesAsync();
            }
        }
    }
}
