using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class PilarHappinessAppService : IPilarHappinessAppService
    {
        private readonly IPilarHappinessRepository _repository;

        public PilarHappinessAppService(IPilarHappinessRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PilarHappinessDto>> GetAllAsync()
        {
            var pilares = await _repository.GetAllAsync();
            return pilares.Select(p => new PilarHappinessDto
            {
                Id = p.Id,
                Pilar = p.Pilar,
                DescricaoPilar = p.DescricaoPilar,
                Ativo = p.Ativo
            });
        }

        public async Task<PilarHappinessDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;

            return new PilarHappinessDto
            {
                Id = p.Id,
                Pilar = p.Pilar,
                DescricaoPilar = p.DescricaoPilar,
                Ativo = p.Ativo
            };
        }

        public async Task AddAsync(PilarHappinessDto dto)
        {
            var pilar = new PilarHappiness
            {
                Pilar = dto.Pilar,
                DescricaoPilar = dto.DescricaoPilar,
                Ativo = dto.Ativo
            };

            await _repository.AddAsync(pilar);
        }

        public async Task UpdateAsync(PilarHappinessDto dto)
        {
            var pilar = await _repository.GetByIdAsync(dto.Id);
            if (pilar == null) return;

            pilar.Pilar = dto.Pilar;
            pilar.DescricaoPilar = dto.DescricaoPilar;
            pilar.Ativo = dto.Ativo;

            await _repository.UpdateAsync(pilar);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
