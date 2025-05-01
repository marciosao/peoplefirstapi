using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class DominioAgilidadeRepository : IDominioAgilidadeRepository
    {
        private readonly PeopleFirstDbContext _context;

        public DominioAgilidadeRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DominioAgilidade>> GetAllAsync()
        {
            return await _context.DominioAgilidade.ToListAsync();
        }

        public async Task<DominioAgilidade?> GetByIdAsync(int id)
        {
            return await _context.DominioAgilidade.FindAsync(id);
        }

        public async Task AddAsync(DominioAgilidade entity)
        {
            _context.DominioAgilidade.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DominioAgilidade entity)
        {
            _context.DominioAgilidade.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.DominioAgilidade.FindAsync(id);
            if (entity != null)
            {
                _context.DominioAgilidade.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.DominioAgilidade.CountAsync();
        }

        public async Task<IEnumerable<DominioAgilidade>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.DominioAgilidade
                                 .OrderBy(d => d.Dominio)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
