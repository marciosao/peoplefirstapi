using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IHealthCheckAppService
    {
        Task<IEnumerable<HealthCheckDto>> GetAllAsync();
        Task<HealthCheckDto?> GetByIdAsync(int id);
        Task AddAsync(HealthCheckDto dto);
        Task UpdateAsync(HealthCheckDto dto);
        Task DeleteAsync(int id);
        Task<PagedResult<HealthCheckDto>> ListarPaginadoAsync(int page, int pageSize);
    }
}
