using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class ItemPilarRepository : IItemPilarRepository
    {
        private readonly PeopleFirstDbContext _context;

        public ItemPilarRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemPilar>> GetAllAsync()
        {
            return await _context.ItensPilar
                .Include(i => i.PilarCompetencia)
                .ToListAsync();
        }

        public async Task<ItemPilar?> GetByIdAsync(int id)
        {
            return await _context.ItensPilar
                .Include(i => i.PilarCompetencia)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task AddAsync(ItemPilar item)
        {
            await _context.ItensPilar.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ItemPilar item)
        {
            _context.ItensPilar.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.ItensPilar.FindAsync(id);
            if (item != null)
            {
                _context.ItensPilar.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
