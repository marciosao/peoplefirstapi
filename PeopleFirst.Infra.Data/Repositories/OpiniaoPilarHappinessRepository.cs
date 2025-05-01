using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class OpiniaoPilarHappinessRepository : IOpiniaoPilarHappinessRepository
    {
        private readonly PeopleFirstDbContext _context;

        public OpiniaoPilarHappinessRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpiniaoPilarHappiness>> GetAllAsync()
        {
            return await _context.OpinioesPilarHappiness
                .Include(p => p.Happiness)
                .Include(p => p.PilarHappiness)
                .ToListAsync();
        }

        public async Task<OpiniaoPilarHappiness?> GetByIdAsync(int id)
        {
            return await _context.OpinioesPilarHappiness
                .Include(p => p.Happiness)
                .Include(p => p.PilarHappiness)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(OpiniaoPilarHappiness item)
        {
            await _context.OpinioesPilarHappiness.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OpiniaoPilarHappiness item)
        {
            _context.OpinioesPilarHappiness.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.OpinioesPilarHappiness.FindAsync(id);
            if (item != null)
            {
                _context.OpinioesPilarHappiness.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.OpinioesPilarHappiness.CountAsync();
        }

        public async Task<IEnumerable<OpiniaoPilarHappiness>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.OpinioesPilarHappiness
                                 .OrderBy(o => o.Id)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
