using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IItemPilarRepository
    {
        Task<IEnumerable<ItemPilar>> GetAllAsync();
        Task<ItemPilar?> GetByIdAsync(int id);
        Task AddAsync(ItemPilar item);
        Task UpdateAsync(ItemPilar item);
        Task DeleteAsync(int id);
    }
}
