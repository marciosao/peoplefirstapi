using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IHappinessAppService
    {
        Task<IEnumerable<HappinessDto>> GetAllAsync();
        Task<HappinessDto?> GetByIdAsync(int id);
        Task AddAsync(HappinessDto dto);
        Task UpdateAsync(HappinessDto dto);
        Task DeleteAsync(int id);
    }
}
