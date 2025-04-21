using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class TipoFeedbackRepository : ITipoFeedbackRepository
    {
        private readonly PeopleFirstDbContext _context;

        public TipoFeedbackRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoFeedback>> GetAllAsync()
        {
            return await _context.TiposFeedback.ToListAsync();
        }

        public async Task<TipoFeedback?> GetByIdAsync(int id)
        {
            return await _context.TiposFeedback.FindAsync(id);
        }

        public async Task AddAsync(TipoFeedback tipo)
        {
            await _context.TiposFeedback.AddAsync(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoFeedback tipo)
        {
            _context.TiposFeedback.Update(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tipo = await _context.TiposFeedback.FindAsync(id);
            if (tipo != null)
            {
                _context.TiposFeedback.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
