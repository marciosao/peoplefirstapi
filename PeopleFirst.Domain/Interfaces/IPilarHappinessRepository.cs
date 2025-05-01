using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IPilarHappinessRepository
    {
        Task<IEnumerable<PilarHappiness>> GetAllAsync();
        Task<PilarHappiness?> GetByIdAsync(int id);
        Task AddAsync(PilarHappiness pilar);
        Task UpdateAsync(PilarHappiness pilar);
        Task DeleteAsync(int id);
        Task<int> ContarAsync();
        Task<IEnumerable<PilarHappiness>> ListarPaginadoAsync(int page, int pageSize);

    }
}
