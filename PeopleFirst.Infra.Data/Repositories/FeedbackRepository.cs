using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly PeopleFirstDbContext _context;

        public FeedbackRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks
                .Include(f => f.Colaborador)
                .Include(f => f.TipoFeedback)
                .ToListAsync();
        }

        public async Task<Feedback?> GetByIdAsync(int id)
        {
            return await _context.Feedbacks
                .Include(f => f.Colaborador)
                .Include(f => f.TipoFeedback)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Feedback feedback)
        {
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.Feedbacks.CountAsync();
        }

        public async Task<IEnumerable<Feedback>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.Feedbacks
                                 .OrderByDescending(f => f.Data)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
