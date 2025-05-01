using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class TimeAppService : ITimeAppService
    {
        private readonly ITimeRepository _repository;

        public TimeAppService(ITimeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TimeDto>> GetAllAsync()
        {
            var times = await _repository.GetAllAsync();
            return times.Select(t => new TimeDto
            {
                Id = t.Id,
                Nome = t.Nome,
                Ativo = t.Ativo
            });
        }

        public async Task<TimeDto?> GetByIdAsync(int id)
        {
            var t = await _repository.GetByIdAsync(id);
            if (t == null) return null;

            return new TimeDto
            {
                Id = t.Id,
                Nome = t.Nome,
                Ativo = t.Ativo
            };
        }

        public async Task AddAsync(TimeDto dto)
        {
            var time = new Time
            {
                Nome = dto.Nome,
                Ativo = dto.Ativo
            };

            await _repository.AddAsync(time);
        }

        public async Task UpdateAsync(TimeDto dto)
        {
            var time = await _repository.GetByIdAsync(dto.Id);
            if (time == null) return;

            time.Nome = dto.Nome;
            time.Ativo = dto.Ativo;

            await _repository.UpdateAsync(time);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<TimeDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var times = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = times.Select(t => new TimeDto
            {
                Id = t.Id,
                Nome = t.Nome,
                Ativo = t.Ativo
            });

            return new PagedResult<TimeDto>(dtos, total, page, pageSize);
        }

    }
}
