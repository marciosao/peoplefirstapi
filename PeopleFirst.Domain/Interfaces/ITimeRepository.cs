using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface ITimeRepository
    {
        Task<IEnumerable<Time>> GetAllAsync();
        Task<Time?> GetByIdAsync(int id);
        Task AddAsync(Time time);
        Task UpdateAsync(Time time);
        Task DeleteAsync(int id);
        Task<int> ContarAsync();
        Task<IEnumerable<Time>> ListarPaginadoAsync(int page, int pageSize);

    }
}
