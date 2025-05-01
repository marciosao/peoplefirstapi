using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class HappinessAppService : IHappinessAppService
    {
        private readonly IHappinessRepository _repository;

        public HappinessAppService(IHappinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HappinessDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(h => new HappinessDto
            {
                Id = h.Id,
                IdColaborador = h.IdColaborador,
                Data = h.Data,
                NotaGeral = h.NotaGeral,
                AvaliacaoGeral = h.AvaliacaoGeral,
                ColaboradorId = h.ColaboradorId,
                ColaboradorPerfilId = h.ColaboradorPerfilId,
                NomeColaborador = h.Colaborador?.Nome
            });
        }

        public async Task<HappinessDto?> GetByIdAsync(int id)
        {
            var h = await _repository.GetByIdAsync(id);
            if (h == null) return null;

            return new HappinessDto
            {
                Id = h.Id,
                IdColaborador = h.IdColaborador,
                Data = h.Data,
                NotaGeral = h.NotaGeral,
                AvaliacaoGeral = h.AvaliacaoGeral,
                ColaboradorId = h.ColaboradorId,
                ColaboradorPerfilId = h.ColaboradorPerfilId,
                NomeColaborador = h.Colaborador?.Nome
            };
        }

        public async Task AddAsync(HappinessDto dto)
        {
            var h = new Happiness
            {
                IdColaborador = dto.IdColaborador,
                Data = dto.Data,
                NotaGeral = dto.NotaGeral,
                AvaliacaoGeral = dto.AvaliacaoGeral,
                ColaboradorId = dto.ColaboradorId,
                ColaboradorPerfilId = dto.ColaboradorPerfilId
            };

            await _repository.AddAsync(h);
        }

        public async Task UpdateAsync(HappinessDto dto)
        {
            var h = await _repository.GetByIdAsync(dto.Id);
            if (h == null) return;

            h.IdColaborador = dto.IdColaborador;
            h.Data = dto.Data;
            h.NotaGeral = dto.NotaGeral;
            h.AvaliacaoGeral = dto.AvaliacaoGeral;
            h.ColaboradorId = dto.ColaboradorId;
            h.ColaboradorPerfilId = dto.ColaboradorPerfilId;

            await _repository.UpdateAsync(h);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<HappinessDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var registros = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = registros.Select(h => new HappinessDto
            {
                Id = h.Id,
                IdColaborador = h.IdColaborador,
                Data = h.Data,
                NotaGeral = h.NotaGeral,
                AvaliacaoGeral = h.AvaliacaoGeral,
                ColaboradorId = h.ColaboradorId,
                ColaboradorPerfilId = h.ColaboradorPerfilId,
                NomeColaborador = h.Colaborador?.Nome
            });

            return new PagedResult<HappinessDto>(dtos, total, page, pageSize);
        }

    }
}
