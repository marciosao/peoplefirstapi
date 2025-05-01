using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class OpiniaoPilarHappinessAppService : IOpiniaoPilarHappinessAppService
    {
        private readonly IOpiniaoPilarHappinessRepository _repository;

        public OpiniaoPilarHappinessAppService(IOpiniaoPilarHappinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OpiniaoPilarHappinessDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(p => new OpiniaoPilarHappinessDto
            {
                Id = p.Id,
                IdHappiness = p.IdHappiness,
                IdPilarHappiness = p.IdPilarHappiness,
                Nota = p.Nota,
                Comentario = p.Comentario,
                // HappinessId = p.HappinessId,
                // PilarHappinessId = p.PilarHappinessId,
                NomePilar = p.PilarHappiness?.Pilar
            });
        }

        public async Task<OpiniaoPilarHappinessDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;

            return new OpiniaoPilarHappinessDto
            {
                Id = p.Id,
                IdHappiness = p.IdHappiness,
                IdPilarHappiness = p.IdPilarHappiness,
                Nota = p.Nota,
                Comentario = p.Comentario,
                // HappinessId = p.HappinessId,
                // PilarHappinessId = p.PilarHappinessId,
                NomePilar = p.PilarHappiness?.Pilar
            };
        }

        public async Task AddAsync(OpiniaoPilarHappinessDto dto)
        {
            var item = new OpiniaoPilarHappiness
            {
                IdHappiness = dto.IdHappiness,
                IdPilarHappiness = dto.IdPilarHappiness,
                Nota = dto.Nota,
                Comentario = dto.Comentario
                // HappinessId = dto.HappinessId,
                // PilarHappinessId = dto.PilarHappinessId
            };

            await _repository.AddAsync(item);
        }

        public async Task UpdateAsync(OpiniaoPilarHappinessDto dto)
        {
            var item = await _repository.GetByIdAsync(dto.Id);
            if (item == null) return;

            item.IdHappiness = dto.IdHappiness;
            item.IdPilarHappiness = dto.IdPilarHappiness;
            item.Nota = dto.Nota;
            item.Comentario = dto.Comentario;
            // item.HappinessId = dto.HappinessId;
            // item.PilarHappinessId = dto.PilarHappinessId;

            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<OpiniaoPilarHappinessDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var opinioes = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = opinioes.Select(p => new OpiniaoPilarHappinessDto
            {
                Id = p.Id,
                IdHappiness = p.IdHappiness,
                IdPilarHappiness = p.IdPilarHappiness,
                Nota = p.Nota,
                Comentario = p.Comentario,
                NomePilar = p.PilarHappiness?.Pilar
            });

            return new PagedResult<OpiniaoPilarHappinessDto>(dtos, total, page, pageSize);
        }

    }
}
