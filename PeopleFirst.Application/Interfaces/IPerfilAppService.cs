using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IPerfilAppService
    {
        Task<IEnumerable<PerfilDto>> GetAllAsync();
        Task<PerfilDto?> GetByIdAsync(int id);
        Task AddAsync(PerfilDto dto);
        Task UpdateAsync(PerfilDto dto);
        Task DeleteAsync(int id);

        Task<PagedResult<PerfilDto>> ListarPaginadoAsync(int page, int pageSize);

    }
}
