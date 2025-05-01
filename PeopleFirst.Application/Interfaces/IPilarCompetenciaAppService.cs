using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IPilarCompetenciaAppService
    {
        Task<IEnumerable<PilarCompetenciaDto>> GetAllAsync();
        Task<PilarCompetenciaDto?> GetByIdAsync(int id);
        Task AddAsync(PilarCompetenciaDto dto);
        Task UpdateAsync(PilarCompetenciaDto dto);
        Task DeleteAsync(int id);
        Task<PagedResult<PilarCompetenciaDto>> ListarPaginadoAsync(int page, int pageSize);

    }
}
