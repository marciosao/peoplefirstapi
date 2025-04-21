using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class TipoFeedbackAppService : ITipoFeedbackAppService
    {
        private readonly ITipoFeedbackRepository _repository;

        public TipoFeedbackAppService(ITipoFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoFeedbackDto>> GetAllAsync()
        {
            var tipos = await _repository.GetAllAsync();
            return tipos.Select(t => new TipoFeedbackDto
            {
                Id = t.Id,
                Tipo = t.Tipo
            });
        }

        public async Task<TipoFeedbackDto?> GetByIdAsync(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) return null;

            return new TipoFeedbackDto
            {
                Id = tipo.Id,
                Tipo = tipo.Tipo
            };
        }

        public async Task AddAsync(TipoFeedbackDto dto)
        {
            var tipo = new TipoFeedback { Tipo = dto.Tipo };
            await _repository.AddAsync(tipo);
        }

        public async Task UpdateAsync(TipoFeedbackDto dto)
        {
            var tipo = await _repository.GetByIdAsync(dto.Id);
            if (tipo == null) return;
            tipo.Tipo = dto.Tipo;
            await _repository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
