using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class HealthCheckRepository : IHealthCheckRepository
    {
        private readonly PeopleFirstDbContext _context;

        public HealthCheckRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HealthCheck>> GetAllAsync()
        {
            return await _context.HealthCheck.ToListAsync();
        }

        public async Task<HealthCheck?> GetByIdAsync(int id)
        {
            return await _context.HealthCheck.FindAsync(id);
        }

        public async Task AddAsync(HealthCheck entity)
        {
            _context.HealthCheck.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(HealthCheck entity)
        {
            _context.HealthCheck.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.HealthCheck.FindAsync(id);
            if (entity != null)
            {
                _context.HealthCheck.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
