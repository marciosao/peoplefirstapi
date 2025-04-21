using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface IPilarCompetenciaRepository
    {
        Task<IEnumerable<PilarCompetencia>> GetAllAsync();
        Task<PilarCompetencia?> GetByIdAsync(int id);
        Task AddAsync(PilarCompetencia pilar);
        Task UpdateAsync(PilarCompetencia pilar);
        Task DeleteAsync(int id);
    }
}
