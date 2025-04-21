using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IQuestaoPilarRepository
    {
        Task<IEnumerable<QuestaoPilar>> GetAllAsync();
        Task<QuestaoPilar?> GetByIdAsync(int id);
        Task AddAsync(QuestaoPilar entity);
        Task UpdateAsync(QuestaoPilar entity);
        Task DeleteAsync(int id);
    }
}
