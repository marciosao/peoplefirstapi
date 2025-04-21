using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Domain.Interfaces
{
    public interface ITipoCompetenciaRepository
    {
        Task<IEnumerable<TipoCompetencia>> GetAllAsync();
        Task<TipoCompetencia?> GetByIdAsync(int id);
        Task AddAsync(TipoCompetencia tipo);
        Task UpdateAsync(TipoCompetencia tipo);
        Task DeleteAsync(int id);
    }
}
