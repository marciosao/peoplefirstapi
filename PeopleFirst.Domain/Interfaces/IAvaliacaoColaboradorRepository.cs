using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IAvaliacaoColaboradorRepository
    {
        Task<IEnumerable<AvaliacaoColaborador>> GetAllAsync();
        Task<AvaliacaoColaborador?> GetByIdAsync(int id);
        Task AddAsync(AvaliacaoColaborador avaliacao);
        Task UpdateAsync(AvaliacaoColaborador avaliacao);
        Task DeleteAsync(int id);
    }
}
