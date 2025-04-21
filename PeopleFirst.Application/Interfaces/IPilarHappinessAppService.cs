using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IPilarHappinessAppService
    {
        Task<IEnumerable<PilarHappinessDto>> GetAllAsync();
        Task<PilarHappinessDto?> GetByIdAsync(int id);
        Task AddAsync(PilarHappinessDto dto);
        Task UpdateAsync(PilarHappinessDto dto);
        Task DeleteAsync(int id);
    }
}
