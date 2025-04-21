using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IOpiniaoPilarHappinessAppService
    {
        Task<IEnumerable<OpiniaoPilarHappinessDto>> GetAllAsync();
        Task<OpiniaoPilarHappinessDto?> GetByIdAsync(int id);
        Task AddAsync(OpiniaoPilarHappinessDto dto);
        Task UpdateAsync(OpiniaoPilarHappinessDto dto);
        Task DeleteAsync(int id);
    }
}
