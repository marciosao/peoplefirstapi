using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IDominioAgilidadeAppService
    {
        Task<IEnumerable<DominioAgilidadeDto>> GetAllAsync();
        Task<DominioAgilidadeDto?> GetByIdAsync(int id);
        Task AddAsync(DominioAgilidadeDto dto);
        Task UpdateAsync(DominioAgilidadeDto dto);
        Task DeleteAsync(int id);
    }
}
