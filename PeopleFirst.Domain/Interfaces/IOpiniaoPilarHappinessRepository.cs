using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IOpiniaoPilarHappinessRepository
    {
        Task<IEnumerable<OpiniaoPilarHappiness>> GetAllAsync();
        Task<OpiniaoPilarHappiness?> GetByIdAsync(int id);
        Task AddAsync(OpiniaoPilarHappiness item);
        Task UpdateAsync(OpiniaoPilarHappiness item);
        Task DeleteAsync(int id);
    }
}
