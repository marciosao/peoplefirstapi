using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class QuestaoPilarRepository : IQuestaoPilarRepository
    {
        private readonly PeopleFirstDbContext _context;

        public QuestaoPilarRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestaoPilar>> GetAllAsync()
        {
            return await _context.QuestaoPilar.ToListAsync();
        }

        public async Task<QuestaoPilar?> GetByIdAsync(int id)
        {
            return await _context.QuestaoPilar.FindAsync(id);
        }

        public async Task AddAsync(QuestaoPilar entity)
        {
            _context.QuestaoPilar.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(QuestaoPilar entity)
        {
            _context.QuestaoPilar.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.QuestaoPilar.FindAsync(id);
            if (entity != null)
            {
                _context.QuestaoPilar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
