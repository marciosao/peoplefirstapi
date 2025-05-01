using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class PilarCompetenciaAppService : IPilarCompetenciaAppService
    {
        private readonly IPilarCompetenciaRepository _repository;
        //private readonly ITipoCompetenciaPerfilRepository _tipoPerfilRepository;

        public PilarCompetenciaAppService(
            IPilarCompetenciaRepository repository)
        {
            _repository = repository;
            // _tipoPerfilRepository = tipoPerfilRepository;
        }

        public async Task<IEnumerable<PilarCompetenciaDto>> GetAllAsync()
        {
            var pilares = await _repository.GetAllAsync();

            return pilares.Select(p => new PilarCompetenciaDto
            {
                Id = p.Id,
                Pilar = p.Pilar,
                Descricao = p.Descricao,
                //TipoCompetenciaPerfilId = p.TipoCompetenciaPerfilId,
                PerfilNome = p.Perfil?.PerfilNome,
                TipoCompetenciaNome = p.TipoCompetencia?.Tipo
            });
        }

        public async Task<PilarCompetenciaDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            if (p == null) return null;

            return new PilarCompetenciaDto
            {
                Id = p.Id,
                Pilar = p.Pilar,
                Descricao = p.Descricao,
                //TipoCompetenciaPerfilId = p.TipoCompetenciaPerfilId,
                PerfilNome = p.Perfil?.PerfilNome,
                TipoCompetenciaNome = p.TipoCompetencia?.Tipo
            };
        }

        public async Task AddAsync(PilarCompetenciaDto dto)
        {
            var pilar = new PilarCompetencia
            {
                Pilar = dto.Pilar,
                Descricao = dto.Descricao,
                PerfilId = dto.PerfilId,
                TipoCompetenciaId = dto.TipoCompetenciaId
            };

            await _repository.AddAsync(pilar);
        }

        public async Task UpdateAsync(PilarCompetenciaDto dto)
        {
            var pilar = await _repository.GetByIdAsync(dto.Id);
            if (pilar == null) return;

            pilar.Pilar = dto.Pilar;
            pilar.Descricao = dto.Descricao;
            pilar.PerfilId = dto.PerfilId;
            pilar.TipoCompetenciaId = dto.TipoCompetenciaId;

            await _repository.UpdateAsync(pilar);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<PilarCompetenciaDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var pilares = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = pilares.Select(p => new PilarCompetenciaDto
            {
                Id = p.Id,
                Pilar = p.Pilar,
                Descricao = p.Descricao,
                PerfilNome = p.Perfil?.PerfilNome,
                TipoCompetenciaNome = p.TipoCompetencia?.Tipo
            });

            return new PagedResult<PilarCompetenciaDto>(dtos, total, page, pageSize);
        }

    }
}
