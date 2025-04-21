using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class ItemPilarAppService : IItemPilarAppService
    {
        private readonly IItemPilarRepository _repository;
        private readonly IPilarCompetenciaRepository _pilarRepository;

        public ItemPilarAppService(IItemPilarRepository repository, IPilarCompetenciaRepository pilarRepository)
        {
            _repository = repository;
            _pilarRepository = pilarRepository;
        }

        public async Task<IEnumerable<ItemPilarDto>> GetAllAsync()
        {
            var itens = await _repository.GetAllAsync();

            return itens.Select(i => new ItemPilarDto
            {
                Id = i.Id,
                Item = i.Item,
                Descricao = i.Descricao,
                PilarCompetenciaId = i.PilarCompetenciaId,
                NomePilar = i.PilarCompetencia?.Pilar
            });
        }

        public async Task<ItemPilarDto?> GetByIdAsync(int id)
        {
            var i = await _repository.GetByIdAsync(id);
            if (i == null) return null;

            return new ItemPilarDto
            {
                Id = i.Id,
                Item = i.Item,
                Descricao = i.Descricao,
                PilarCompetenciaId = i.PilarCompetenciaId,
                NomePilar = i.PilarCompetencia?.Pilar
            };
        }

        public async Task AddAsync(ItemPilarDto dto)
        {
            var item = new ItemPilar
            {
                Item = dto.Item,
                Descricao = dto.Descricao,
                PilarCompetenciaId = dto.PilarCompetenciaId
            };

            await _repository.AddAsync(item);
        }

        public async Task UpdateAsync(ItemPilarDto dto)
        {
            var item = await _repository.GetByIdAsync(dto.Id);
            if (item == null) return;

            item.Item = dto.Item;
            item.Descricao = dto.Descricao;
            item.PilarCompetenciaId = dto.PilarCompetenciaId;

            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
