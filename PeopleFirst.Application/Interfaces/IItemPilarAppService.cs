using PeopleFirst.Application.DTOs;

namespace PeopleFirst.Application.Interfaces
{
    public interface IItemPilarAppService
    {
        Task<IEnumerable<ItemPilarDto>> GetAllAsync();
        Task<ItemPilarDto?> GetByIdAsync(int id);
        Task AddAsync(ItemPilarDto dto);
        Task UpdateAsync(ItemPilarDto dto);
        Task DeleteAsync(int id);
        Task<PagedResult<ItemPilarDto>> ListarPaginadoAsync(int page, int pageSize);

    }
}
