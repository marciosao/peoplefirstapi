using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IPerfilRepository
    {
        Task<IEnumerable<Perfil>> GetAllAsync();
        Task<Perfil> GetByIdAsync(int id);
        Task AddAsync(Perfil perfil);
        Task UpdateAsync(Perfil perfil);
        Task DeleteAsync(int id);
    }
}
