using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class AvaliacaoHealthCheckAppService : IAvaliacaoHealthCheckAppService
    {
        private readonly IAvaliacaoHealthCheckRepository _repository;

        public AvaliacaoHealthCheckAppService(IAvaliacaoHealthCheckRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AvaliacaoHealthCheckDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(a => new AvaliacaoHealthCheckDto
            {
                Id = a.Id,
                HealthCheckId = a.HealthCheckId,
                TimeId = a.TimeId,
                QuestaoPilarId = a.QuestaoPilarId,
                PilarDominioId = a.PilarDominioId,
                DominioAgilidadeId = a.DominioAgilidadeId,
                NotaFinal = a.NotaFinal,
                Observacoes = a.Observacoes
            });
        }

        public async Task<AvaliacaoHealthCheckDto?> GetByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new AvaliacaoHealthCheckDto
            {
                Id = a.Id,
                HealthCheckId = a.HealthCheckId,
                TimeId = a.TimeId,
                QuestaoPilarId = a.QuestaoPilarId,
                PilarDominioId = a.PilarDominioId,
                DominioAgilidadeId = a.DominioAgilidadeId,
                NotaFinal = a.NotaFinal,
                Observacoes = a.Observacoes
            };
        }

        public async Task AddAsync(AvaliacaoHealthCheckDto dto)
        {
            var entity = new AvaliacaoHealthCheck
            {
                HealthCheckId = dto.HealthCheckId,
                TimeId = dto.TimeId,
                QuestaoPilarId = dto.QuestaoPilarId,
                PilarDominioId = dto.PilarDominioId,
                DominioAgilidadeId = dto.DominioAgilidadeId,
                NotaFinal = dto.NotaFinal,
                Observacoes = dto.Observacoes
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(AvaliacaoHealthCheckDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.HealthCheckId = dto.HealthCheckId;
            entity.TimeId = dto.TimeId;
            entity.QuestaoPilarId = dto.QuestaoPilarId;
            entity.PilarDominioId = dto.PilarDominioId;
            entity.DominioAgilidadeId = dto.DominioAgilidadeId;
            entity.NotaFinal = dto.NotaFinal;
            entity.Observacoes = dto.Observacoes;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
