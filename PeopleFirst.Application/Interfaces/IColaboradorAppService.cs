using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IColaboradorAppService
    {
        Task<IEnumerable<ColaboradorDto>> GetAllAsync();
        Task<ColaboradorDto?> GetByIdAsync(int id);
        Task AddAsync(ColaboradorDto dto);
        Task UpdateAsync(ColaboradorDto dto);
        Task DeleteAsync(int id);
    }
}
