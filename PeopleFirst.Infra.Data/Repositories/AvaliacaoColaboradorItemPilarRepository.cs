using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class AvaliacaoColaboradorItemPilarRepository : IAvaliacaoColaboradorItemPilarRepository
    {
        private readonly PeopleFirstDbContext _context;

        public AvaliacaoColaboradorItemPilarRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AvaliacaoColaboradorItemPilar>> GetAllAsync()
        {
            return await _context.AvaliacoesItensPilar
                .Include(x => x.AvaliacaoColaborador)
                .Include(x => x.ItemPilar)
                .ToListAsync();
        }

        public async Task<AvaliacaoColaboradorItemPilar?> GetByIdAsync(int id)
        {
            return await _context.AvaliacoesItensPilar
                .Include(x => x.AvaliacaoColaborador)
                .Include(x => x.ItemPilar)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(AvaliacaoColaboradorItemPilar item)
        {
            await _context.AvaliacoesItensPilar.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AvaliacaoColaboradorItemPilar item)
        {
            _context.AvaliacoesItensPilar.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.AvaliacoesItensPilar.FindAsync(id);
            if (item != null)
            {
                _context.AvaliacoesItensPilar.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.AvaliacoesItensPilar.CountAsync();
        }

        public async Task<IEnumerable<AvaliacaoColaboradorItemPilar>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.AvaliacoesItensPilar
                                 .OrderBy(i => i.Id)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
