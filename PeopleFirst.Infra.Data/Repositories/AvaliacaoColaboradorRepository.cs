using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;
using PeopleFirst.Infra.Data.Context;

namespace PeopleFirst.Infra.Data.Repositories
{
    public class AvaliacaoColaboradorRepository : IAvaliacaoColaboradorRepository
    {
        private readonly PeopleFirstDbContext _context;

        public AvaliacaoColaboradorRepository(PeopleFirstDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AvaliacaoColaborador>> GetAllAsync()
        {
            return await _context.AvaliacoesColaborador.Include(a => a.Colaborador).ToListAsync();
        }

        public async Task<AvaliacaoColaborador?> GetByIdAsync(int id)
        {
            return await _context.AvaliacoesColaborador
                .Include(a => a.Colaborador)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAsync(AvaliacaoColaborador avaliacao)
        {
            await _context.AvaliacoesColaborador.AddAsync(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AvaliacaoColaborador avaliacao)
        {
            _context.AvaliacoesColaborador.Update(avaliacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var avaliacao = await _context.AvaliacoesColaborador.FindAsync(id);
            if (avaliacao != null)
            {
                _context.AvaliacoesColaborador.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> ContarAsync()
        {
            return await _context.AvaliacoesColaborador.CountAsync();
        }

        public async Task<IEnumerable<AvaliacaoColaborador>> ListarPaginadoAsync(int page, int pageSize)
        {
            return await _context.AvaliacoesColaborador
                                 .Include(a => a.Colaborador)
                                 .OrderByDescending(a => a.Data)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

    }
}
