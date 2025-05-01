using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface ITipoFeedbackRepository
    {
        Task<IEnumerable<TipoFeedback>> GetAllAsync();
        Task<TipoFeedback?> GetByIdAsync(int id);
        Task AddAsync(TipoFeedback tipo);
        Task UpdateAsync(TipoFeedback tipo);
        Task DeleteAsync(int id);

        Task<int> ContarAsync();
        Task<IEnumerable<TipoFeedback>> ListarPaginadoAsync(int page, int pageSize);

    }
}
