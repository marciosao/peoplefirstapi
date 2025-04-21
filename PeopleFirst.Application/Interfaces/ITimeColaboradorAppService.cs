using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface ITimeColaboradorAppService
    {
        Task<IEnumerable<TimeColaboradorDto>> GetAllAsync();
        Task<TimeColaboradorDto?> GetByIdAsync(int id);
        Task AddAsync(TimeColaboradorDto dto);
        Task UpdateAsync(TimeColaboradorDto dto);
        Task DeleteAsync(int id);
    }
}
