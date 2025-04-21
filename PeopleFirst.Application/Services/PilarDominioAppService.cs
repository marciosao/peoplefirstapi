using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class PilarDominioAppService : IPilarDominioAppService
    {
        private readonly IPilarDominioRepository _repository;

        public PilarDominioAppService(IPilarDominioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PilarDominioDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(p => new PilarDominioDto
            {
                Id = p.Id,
                Pilar = p.Pilar,
                DominioAgilidadeId = p.DominioAgilidadeId
            });
        }

        public async Task<PilarDominioDto?> GetByIdAsync(int id)
        {
            var pilar = await _repository.GetByIdAsync(id);
            if (pilar == null) return null;

            return new PilarDominioDto
            {
                Id = pilar.Id,
                Pilar = pilar.Pilar,
                DominioAgilidadeId = pilar.DominioAgilidadeId
            };
        }

        public async Task AddAsync(PilarDominioDto dto)
        {
            var entity = new PilarDominio
            {
                Pilar = dto.Pilar,
                DominioAgilidadeId = dto.DominioAgilidadeId
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(PilarDominioDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.Pilar = dto.Pilar;
            entity.DominioAgilidadeId = dto.DominioAgilidadeId;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
