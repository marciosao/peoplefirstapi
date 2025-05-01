using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class HealthCheckAppService : IHealthCheckAppService
    {
        private readonly IHealthCheckRepository _repository;

        public HealthCheckAppService(IHealthCheckRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HealthCheckDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(h => new HealthCheckDto
            {
                Id = h.Id,
                TimeId = h.TimeId,
                IdFacilitador = h.IdFacilitador,
                DataExecucao = h.DataExecucao,
                NotaGeral = h.NotaGeral,
                ConsideracoesFinais = h.ConsideracoesFinais
            });
        }

        public async Task<HealthCheckDto?> GetByIdAsync(int id)
        {
            var h = await _repository.GetByIdAsync(id);
            if (h == null) return null;

            return new HealthCheckDto
            {
                Id = h.Id,
                TimeId = h.TimeId,
                IdFacilitador = h.IdFacilitador,
                DataExecucao = h.DataExecucao,
                NotaGeral = h.NotaGeral,
                ConsideracoesFinais = h.ConsideracoesFinais
            };
        }

        public async Task AddAsync(HealthCheckDto dto)
        {
            var entity = new HealthCheck
            {
                TimeId = dto.TimeId,
                IdFacilitador = dto.IdFacilitador,
                DataExecucao = dto.DataExecucao,
                NotaGeral = dto.NotaGeral,
                ConsideracoesFinais = dto.ConsideracoesFinais
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(HealthCheckDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.TimeId = dto.TimeId;
            entity.IdFacilitador = dto.IdFacilitador;
            entity.DataExecucao = dto.DataExecucao;
            entity.NotaGeral = dto.NotaGeral;
            entity.ConsideracoesFinais = dto.ConsideracoesFinais;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<HealthCheckDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var registros = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = registros.Select(h => new HealthCheckDto
            {
                Id = h.Id,
                TimeId = h.TimeId,
                IdFacilitador = h.IdFacilitador,
                DataExecucao = h.DataExecucao,
                NotaGeral = h.NotaGeral,
                ConsideracoesFinais = h.ConsideracoesFinais
            });

            return new PagedResult<HealthCheckDto>(dtos, total, page, pageSize);
        }

    }
}
