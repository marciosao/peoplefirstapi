using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IAvaliacaoColaboradorAppService
    {
        Task<IEnumerable<AvaliacaoColaboradorDto>> GetAllAsync();
        Task<AvaliacaoColaboradorDto?> GetByIdAsync(int id);
        Task AddAsync(AvaliacaoColaboradorDto dto);
        Task UpdateAsync(AvaliacaoColaboradorDto dto);
        Task DeleteAsync(int id);
    }
}
