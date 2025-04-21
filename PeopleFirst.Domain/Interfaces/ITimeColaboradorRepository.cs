using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface ITimeColaboradorRepository
    {
        Task<IEnumerable<TimeColaborador>> GetAllAsync();
        Task<TimeColaborador?> GetByIdAsync(int id);
        Task AddAsync(TimeColaborador item);
        Task UpdateAsync(TimeColaborador item);
        Task DeleteAsync(int id);
    }
}
