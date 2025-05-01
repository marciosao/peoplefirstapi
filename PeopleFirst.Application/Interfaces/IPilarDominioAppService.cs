using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IPilarDominioAppService
    {
        Task<IEnumerable<PilarDominioDto>> GetAllAsync();
        Task<PilarDominioDto?> GetByIdAsync(int id);
        Task AddAsync(PilarDominioDto dto);
        Task UpdateAsync(PilarDominioDto dto);
        Task DeleteAsync(int id);
        Task<PagedResult<PilarDominioDto>> ListarPaginadoAsync(int page, int pageSize);
    }
}
