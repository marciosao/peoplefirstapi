using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class PerfilAppService : IPerfilAppService
    {
        private readonly IPerfilRepository _repository;

        public PerfilAppService(IPerfilRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PerfilDto>> GetAllAsync()
        {
            var perfis = await _repository.GetAllAsync();
            return perfis.Select(p => new PerfilDto
            {
                Id = p.Id,
                PerfilNome = p.PerfilNome
            });
        }

        public async Task<PerfilDto?> GetByIdAsync(int id)
        {
            var perfil = await _repository.GetByIdAsync(id);
            if (perfil == null) return null;

            return new PerfilDto
            {
                Id = perfil.Id,
                PerfilNome = perfil.PerfilNome
            };
        }

        public async Task AddAsync(PerfilDto dto)
        {
            var perfil = new Perfil
            {
                PerfilNome = dto.PerfilNome
            };
            await _repository.AddAsync(perfil);
        }

        public async Task UpdateAsync(PerfilDto dto)
        {
            var perfil = await _repository.GetByIdAsync(dto.Id);
            if (perfil == null) return;

            perfil.PerfilNome = dto.PerfilNome;
            await _repository.UpdateAsync(perfil);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
