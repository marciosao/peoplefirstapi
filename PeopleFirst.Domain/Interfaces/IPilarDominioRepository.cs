using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IPilarDominioRepository
    {
        Task<IEnumerable<PilarDominio>> GetAllAsync();
        Task<PilarDominio?> GetByIdAsync(int id);
        Task AddAsync(PilarDominio entity);
        Task UpdateAsync(PilarDominio entity);
        Task DeleteAsync(int id);
        Task<int> ContarAsync();
        Task<IEnumerable<PilarDominio>> ListarPaginadoAsync(int page, int pageSize);
    }
}
