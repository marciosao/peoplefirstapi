using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface ITipoFeedbackAppService
    {
        Task<IEnumerable<TipoFeedbackDto>> GetAllAsync();
        Task<TipoFeedbackDto?> GetByIdAsync(int id);
        Task AddAsync(TipoFeedbackDto dto);
        Task UpdateAsync(TipoFeedbackDto dto);
        Task DeleteAsync(int id);
    }
}
