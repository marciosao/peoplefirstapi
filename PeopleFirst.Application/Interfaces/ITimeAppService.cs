using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface ITimeAppService
    {
        Task<IEnumerable<TimeDto>> GetAllAsync();
        Task<TimeDto?> GetByIdAsync(int id);
        Task AddAsync(TimeDto dto);
        Task UpdateAsync(TimeDto dto);
        Task DeleteAsync(int id);
        Task<PagedResult<TimeDto>> ListarPaginadoAsync(int page, int pageSize);

    }
}
