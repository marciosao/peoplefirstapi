using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IAvaliacaoHealthCheckRepository
    {
        Task<IEnumerable<AvaliacaoHealthCheck>> GetAllAsync();
        Task<AvaliacaoHealthCheck?> GetByIdAsync(int id);
        Task AddAsync(AvaliacaoHealthCheck entity);
        Task UpdateAsync(AvaliacaoHealthCheck entity);
        Task DeleteAsync(int id);
        Task<int> ContarAsync();
        Task<IEnumerable<AvaliacaoHealthCheck>> ListarPaginadoAsync(int page, int pageSize);
    }
}
