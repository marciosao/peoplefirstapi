using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IAvaliacaoHealthCheckAppService
    {
        Task<IEnumerable<AvaliacaoHealthCheckDto>> GetAllAsync();
        Task<AvaliacaoHealthCheckDto?> GetByIdAsync(int id);
        Task AddAsync(AvaliacaoHealthCheckDto dto);
        Task UpdateAsync(AvaliacaoHealthCheckDto dto);
        Task DeleteAsync(int id);
    }
}
