using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IHappinessRepository
    {
        Task<IEnumerable<Happiness>> GetAllAsync();
        Task<Happiness?> GetByIdAsync(int id);
        Task AddAsync(Happiness h);
        Task UpdateAsync(Happiness h);
        Task DeleteAsync(int id);

        Task<int> ContarAsync();
        Task<IEnumerable<Happiness>> ListarPaginadoAsync(int page, int pageSize);

    }
}
