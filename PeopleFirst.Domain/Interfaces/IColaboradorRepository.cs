using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<IEnumerable<Colaborador>> GetAllAsync();
        Task<Colaborador?> GetByIdAsync(int id);
        Task AddAsync(Colaborador colaborador);
        Task UpdateAsync(Colaborador colaborador);
        Task DeleteAsync(int id);
        Task<Colaborador?> BuscarPorEmail(string email);
    }
}
