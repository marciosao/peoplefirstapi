using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class PilarDominioRepository : IPilarDominioRepository
    {
        private readonly PeopleFirstDbContext _context;

        public PilarDominioRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PilarDominio>> GetAllAsync()
        {
            return await _context.PilarDominio.ToListAsync();
        }

        public async Task<PilarDominio?> GetByIdAsync(int id)
        {
            return await _context.PilarDominio.FindAsync(id);
        }

        public async Task AddAsync(PilarDominio entity)
        {
            _context.PilarDominio.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PilarDominio entity)
        {
            _context.PilarDominio.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.PilarDominio.FindAsync(id);
            if (entity != null)
            {
                _context.PilarDominio.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.PilarDominio.CountAsync();
        }

        public async Task<IEnumerable<PilarDominio>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.PilarDominio
                                 .OrderBy(p => p.Pilar)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
