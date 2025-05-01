using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class QuestaoPilarAppService : IQuestaoPilarAppService
    {
        private readonly IQuestaoPilarRepository _repository;

        public QuestaoPilarAppService(IQuestaoPilarRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QuestaoPilarDto>> GetAllAsync()
        {
            var lista = await _repository.GetAllAsync();
            return lista.Select(q => new QuestaoPilarDto
            {
                Id = q.Id,
                Questao = q.Questao,
                PilarDominioId = q.PilarDominioId,
                DominioAgilidadeId = q.DominioAgilidadeId
            });
        }

        public async Task<QuestaoPilarDto?> GetByIdAsync(int id)
        {
            var questao = await _repository.GetByIdAsync(id);
            if (questao == null) return null;

            return new QuestaoPilarDto
            {
                Id = questao.Id,
                Questao = questao.Questao,
                PilarDominioId = questao.PilarDominioId,
                DominioAgilidadeId = questao.DominioAgilidadeId
            };
        }

        public async Task AddAsync(QuestaoPilarDto dto)
        {
            var entity = new QuestaoPilar
            {
                Questao = dto.Questao,
                PilarDominioId = dto.PilarDominioId,
                DominioAgilidadeId = dto.DominioAgilidadeId
            };

            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(QuestaoPilarDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null) return;

            entity.Questao = dto.Questao;
            entity.PilarDominioId = dto.PilarDominioId;
            entity.DominioAgilidadeId = dto.DominioAgilidadeId;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<QuestaoPilarDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var questoes = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = questoes.Select(q => new QuestaoPilarDto
            {
                Id = q.Id,
                Questao = q.Questao,
                PilarDominioId = q.PilarDominioId,
                DominioAgilidadeId = q.DominioAgilidadeId
            });

            return new PagedResult<QuestaoPilarDto>(dtos, total, page, pageSize);
        }

    }
}
