using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class HappinessRepository : IHappinessRepository
    {
        private readonly PeopleFirstDbContext _context;

        public HappinessRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Happiness>> GetAllAsync()
        {
            return await _context.Happinesses
                .Include(h => h.Colaborador)
                .ToListAsync();
        }

        public async Task<Happiness?> GetByIdAsync(int id)
        {
            return await _context.Happinesses
                .Include(h => h.Colaborador)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task AddAsync(Happiness h)
        {
            await _context.Happinesses.AddAsync(h);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Happiness h)
        {
            _context.Happinesses.Update(h);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var h = await _context.Happinesses.FindAsync(id);
            if (h != null)
            {
                _context.Happinesses.Remove(h);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.Happinesses.CountAsync();
        }

        public async Task<IEnumerable<Happiness>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.Happinesses
                                 .OrderByDescending(h => h.Data)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
