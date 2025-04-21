using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IAvaliacaoColaboradorItemPilarRepository
    {
        Task<IEnumerable<AvaliacaoColaboradorItemPilar>> GetAllAsync();
        Task<AvaliacaoColaboradorItemPilar?> GetByIdAsync(int id);
        Task AddAsync(AvaliacaoColaboradorItemPilar item);
        Task UpdateAsync(AvaliacaoColaboradorItemPilar item);
        Task DeleteAsync(int id);
    }
}
