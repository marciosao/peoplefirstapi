using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IQuestaoPilarAppService
    {
        Task<IEnumerable<QuestaoPilarDto>> GetAllAsync();
        Task<QuestaoPilarDto?> GetByIdAsync(int id);
        Task AddAsync(QuestaoPilarDto dto);
        Task UpdateAsync(QuestaoPilarDto dto);
        Task DeleteAsync(int id);
    }
}
