using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class DominioAgilidadeAppService : IDominioAgilidadeAppService
    {
        private readonly IDominioAgilidadeRepository _repository;

        public DominioAgilidadeAppService(IDominioAgilidadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DominioAgilidadeDto>> GetAllAsync()
        {
            var dominios = await _repository.GetAllAsync();

            return dominios.Select(d => new DominioAgilidadeDto
            {
                Id = d.Id,
                Dominio = d.Dominio
            });
        }

        public async Task<DominioAgilidadeDto?> GetByIdAsync(int id)
        {
            var d = await _repository.GetByIdAsync(id);
            if (d == null) return null;

            return new DominioAgilidadeDto
            {
                Id = d.Id,
                Dominio = d.Dominio
            };
        }

        public async Task AddAsync(DominioAgilidadeDto dto)
        {
            var d = new DominioAgilidade
            {
                Dominio = dto.Dominio
            };

            await _repository.AddAsync(d);
        }

        public async Task UpdateAsync(DominioAgilidadeDto dto)
        {
            var d = await _repository.GetByIdAsync(dto.Id);
            if (d == null) return;

            d.Dominio = dto.Dominio;

            await _repository.UpdateAsync(d);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
