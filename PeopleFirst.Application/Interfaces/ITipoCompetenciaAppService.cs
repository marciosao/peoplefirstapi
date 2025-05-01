using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface ITipoCompetenciaAppService
    {
        Task<IEnumerable<TipoCompetenciaDto>> GetAllAsync();
        Task<TipoCompetenciaDto?> GetByIdAsync(int id);
        Task AddAsync(TipoCompetenciaDto dto);
        Task UpdateAsync(TipoCompetenciaDto dto);
        Task DeleteAsync(int id);

        Task<PagedResult<TipoCompetenciaDto>> ListarPaginadoAsync(int page, int pageSize);

    }
}
