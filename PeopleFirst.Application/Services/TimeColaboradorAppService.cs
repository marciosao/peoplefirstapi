using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class TimeColaboradorAppService : ITimeColaboradorAppService
    {
        private readonly ITimeColaboradorRepository _repository;

        public TimeColaboradorAppService(ITimeColaboradorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TimeColaboradorDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(tc => new TimeColaboradorDto
            {
                Id = tc.Id,
                IdTime = tc.IdTime,
                IdColaborador = tc.IdColaborador,
                TimeId = tc.TimeId,
                ColaboradorId = tc.ColaboradorId,
                NomeTime = tc.Time?.Nome,
                NomeColaborador = tc.Colaborador?.Nome
            });
        }

        public async Task<TimeColaboradorDto?> GetByIdAsync(int id)
        {
            var tc = await _repository.GetByIdAsync(id);
            if (tc == null) return null;

            return new TimeColaboradorDto
            {
                Id = tc.Id,
                IdTime = tc.IdTime,
                IdColaborador = tc.IdColaborador,
                TimeId = tc.TimeId,
                ColaboradorId = tc.ColaboradorId,
                NomeTime = tc.Time?.Nome,
                NomeColaborador = tc.Colaborador?.Nome
            };
        }

        public async Task AddAsync(TimeColaboradorDto dto)
        {
            var tc = new TimeColaborador
            {
                IdTime = dto.IdTime,
                IdColaborador = dto.IdColaborador,
                TimeId = dto.TimeId,
                ColaboradorId = dto.ColaboradorId
            };

            await _repository.AddAsync(tc);
        }

        public async Task UpdateAsync(TimeColaboradorDto dto)
        {
            var tc = await _repository.GetByIdAsync(dto.Id);
            if (tc == null) return;

            tc.IdTime = dto.IdTime;
            tc.IdColaborador = dto.IdColaborador;
            tc.TimeId = dto.TimeId;
            tc.ColaboradorId = dto.ColaboradorId;

            await _repository.UpdateAsync(tc);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<TimeColaboradorDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var itens = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = itens.Select(tc => new TimeColaboradorDto
            {
                Id = tc.Id,
                IdTime = tc.IdTime,
                IdColaborador = tc.IdColaborador,
                TimeId = tc.TimeId,
                ColaboradorId = tc.ColaboradorId,
                NomeTime = tc.Time?.Nome,
                NomeColaborador = tc.Colaborador?.Nome
            });

            return new PagedResult<TimeColaboradorDto>(dtos, total, page, pageSize);
        }

    }
}
