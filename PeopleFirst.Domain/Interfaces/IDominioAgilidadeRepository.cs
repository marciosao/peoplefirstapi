using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IDominioAgilidadeRepository
    {
        Task<IEnumerable<DominioAgilidade>> GetAllAsync();
        Task<DominioAgilidade?> GetByIdAsync(int id);
        Task AddAsync(DominioAgilidade entity);
        Task UpdateAsync(DominioAgilidade entity);
        Task DeleteAsync(int id);
        Task<int> ContarAsync();
        Task<IEnumerable<DominioAgilidade>> ListarPaginadoAsync(int page, int pageSize);

    }
}
