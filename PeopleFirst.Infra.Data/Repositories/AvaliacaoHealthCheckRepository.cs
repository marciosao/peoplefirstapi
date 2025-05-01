using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class AvaliacaoHealthCheckRepository : IAvaliacaoHealthCheckRepository
    {
        private readonly PeopleFirstDbContext _context;

        public AvaliacaoHealthCheckRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AvaliacaoHealthCheck>> GetAllAsync()
        {
            return await _context.AvaliacaoHealthCheck.ToListAsync();
        }

        public async Task<AvaliacaoHealthCheck?> GetByIdAsync(int id)
        {
            return await _context.AvaliacaoHealthCheck.FindAsync(id);
        }

        public async Task AddAsync(AvaliacaoHealthCheck entity)
        {
            _context.AvaliacaoHealthCheck.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AvaliacaoHealthCheck entity)
        {
            _context.AvaliacaoHealthCheck.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.AvaliacaoHealthCheck.FindAsync(id);
            if (entity != null)
            {
                _context.AvaliacaoHealthCheck.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.AvaliacaoHealthCheck.CountAsync();
        }

        public async Task<IEnumerable<AvaliacaoHealthCheck>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.AvaliacaoHealthCheck
                                 .OrderBy(a => a.Id)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}
