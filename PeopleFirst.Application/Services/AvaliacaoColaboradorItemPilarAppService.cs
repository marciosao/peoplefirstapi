using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class AvaliacaoColaboradorItemPilarAppService : IAvaliacaoColaboradorItemPilarAppService
    {
        private readonly IAvaliacaoColaboradorItemPilarRepository _repository;

        public AvaliacaoColaboradorItemPilarAppService(
            IAvaliacaoColaboradorItemPilarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AvaliacaoColaboradorItemPilarDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();

            return lista.Select(a => new AvaliacaoColaboradorItemPilarDto
            {
                Id = a.Id,
                IdAvaliacaoColaborador = a.IdAvaliacaoColaborador,
                IdItemPilar = a.IdItemPilar,
                Nota = a.Nota,
                AvaliacaoColaboradorId = a.AvaliacaoColaboradorId,
                ItemPilarId = a.ItemPilarId,
                NomeItemPilar = a.ItemPilar?.Item,
                NomeColaborador = a.AvaliacaoColaborador?.Colaborador?.Nome
            });
        }

        public async Task<AvaliacaoColaboradorItemPilarDto?> GetByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new AvaliacaoColaboradorItemPilarDto
            {
                Id = a.Id,
                IdAvaliacaoColaborador = a.IdAvaliacaoColaborador,
                IdItemPilar = a.IdItemPilar,
                Nota = a.Nota,
                AvaliacaoColaboradorId = a.AvaliacaoColaboradorId,
                ItemPilarId = a.ItemPilarId,
                NomeItemPilar = a.ItemPilar?.Item,
                NomeColaborador = a.AvaliacaoColaborador?.Colaborador?.Nome
            };
        }

        public async Task AddAsync(AvaliacaoColaboradorItemPilarDto dto)
        {
            var item = new AvaliacaoColaboradorItemPilar
            {
                IdAvaliacaoColaborador = dto.IdAvaliacaoColaborador,
                IdItemPilar = dto.IdItemPilar,
                Nota = dto.Nota,
                AvaliacaoColaboradorId = dto.AvaliacaoColaboradorId,
                ItemPilarId = dto.ItemPilarId
            };

            await _repository.AddAsync(item);
        }

        public async Task UpdateAsync(AvaliacaoColaboradorItemPilarDto dto)
        {
            var item = await _repository.GetByIdAsync(dto.Id);
            if (item == null) return;

            item.IdAvaliacaoColaborador = dto.IdAvaliacaoColaborador;
            item.IdItemPilar = dto.IdItemPilar;
            item.Nota = dto.Nota;
            item.AvaliacaoColaboradorId = dto.AvaliacaoColaboradorId;
            item.ItemPilarId = dto.ItemPilarId;

            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<AvaliacaoColaboradorItemPilarDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var itens = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = itens.Select(a => new AvaliacaoColaboradorItemPilarDto
            {
                Id = a.Id,
                IdAvaliacaoColaborador = a.IdAvaliacaoColaborador,
                IdItemPilar = a.IdItemPilar,
                Nota = a.Nota,
                AvaliacaoColaboradorId = a.AvaliacaoColaboradorId,
                ItemPilarId = a.ItemPilarId,
                NomeItemPilar = a.ItemPilar?.Item,
                NomeColaborador = a.AvaliacaoColaborador?.Colaborador?.Nome
            });

            return new PagedResult<AvaliacaoColaboradorItemPilarDto>(dtos, total, page, pageSize);
        }

    }
}
