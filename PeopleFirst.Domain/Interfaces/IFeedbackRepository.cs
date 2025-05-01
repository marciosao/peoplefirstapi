using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllAsync();
        Task<Feedback?> GetByIdAsync(int id);
        Task AddAsync(Feedback feedback);
        Task UpdateAsync(Feedback feedback);
        Task DeleteAsync(int id);

        Task<int> ContarAsync();
        Task<IEnumerable<Feedback>> ListarPaginadoAsync(int page, int pageSize);

    }
}
