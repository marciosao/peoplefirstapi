using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class TipoCompetenciaAppService : ITipoCompetenciaAppService
    {
        private readonly ITipoCompetenciaRepository _repository;

        public TipoCompetenciaAppService(ITipoCompetenciaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoCompetenciaDto>> GetAllAsync()
        {
            var tipos = await _repository.GetAllAsync();
            return tipos.Select(t => new TipoCompetenciaDto
            {
                Id = t.Id,
                Tipo = t.Tipo
            });
        }

        public async Task<TipoCompetenciaDto?> GetByIdAsync(int id)
        {
            var tipo = await _repository.GetByIdAsync(id);
            if (tipo == null) return null;

            return new TipoCompetenciaDto
            {
                Id = tipo.Id,
                Tipo = tipo.Tipo
            };
        }

        public async Task AddAsync(TipoCompetenciaDto dto)
        {
            var tipo = new TipoCompetencia
            {
                Tipo = dto.Tipo
            };

            await _repository.AddAsync(tipo);
        }

        public async Task UpdateAsync(TipoCompetenciaDto dto)
        {
            var tipo = await _repository.GetByIdAsync(dto.Id);
            if (tipo == null) return;

            tipo.Tipo = dto.Tipo;
            //tipo.TipoCompetenciaNome = dto.TipoCompetenciaCol;

            await _repository.UpdateAsync(tipo);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<TipoCompetenciaDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var tipos = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = tipos.Select(t => new TipoCompetenciaDto
            {
                Id = t.Id,
                Tipo = t.Tipo
            });

            return new PagedResult<TipoCompetenciaDto>(dtos, total, page, pageSize);
        }

    }
}
