using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IFeedbackAppService
    {
        Task<IEnumerable<FeedbackDto>> GetAllAsync();
        Task<FeedbackDto?> GetByIdAsync(int id);
        Task AddAsync(FeedbackDto dto);
        Task UpdateAsync(FeedbackDto dto);
        Task DeleteAsync(int id);
    }
}
