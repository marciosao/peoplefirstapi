using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IHealthCheckRepository
    {
        Task<IEnumerable<HealthCheck>> GetAllAsync();
        Task<HealthCheck?> GetByIdAsync(int id);
        Task AddAsync(HealthCheck entity);
        Task UpdateAsync(HealthCheck entity);
        Task DeleteAsync(int id);
    }
}
