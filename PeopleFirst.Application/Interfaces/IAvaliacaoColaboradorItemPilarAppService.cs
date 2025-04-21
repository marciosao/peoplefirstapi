using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IAvaliacaoColaboradorItemPilarAppService
    {
        Task<IEnumerable<AvaliacaoColaboradorItemPilarDto>> GetAllAsync();
        Task<AvaliacaoColaboradorItemPilarDto?> GetByIdAsync(int id);
        Task AddAsync(AvaliacaoColaboradorItemPilarDto dto);
        Task UpdateAsync(AvaliacaoColaboradorItemPilarDto dto);
        Task DeleteAsync(int id);
    }
}
