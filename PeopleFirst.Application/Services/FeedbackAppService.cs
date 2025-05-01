using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class FeedbackAppService : IFeedbackAppService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackAppService(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FeedbackDto>> GetAllAsync()
        {
            var feedbacks = await _repository.GetAllAsync();

            return feedbacks.Select(f => new FeedbackDto
            {
                Id = f.Id,
                IdColaborador = f.IdColaborador,
                IdLider = f.IdLider,
                IdTipoFeedback = f.IdTipoFeedback,
                Observacoes = f.Observacoes,
                Data = f.Data,
                Percepcao = f.Percepcao,
                PlanoAcao = f.PlanoAcao,
                ColaboradorId = f.ColaboradorId,
                TipoFeedbackId = f.TipoFeedbackId,
                NomeColaborador = f.Colaborador?.Nome,
                TipoFeedbackDescricao = f.TipoFeedback?.Tipo
            });
        }

        public async Task<FeedbackDto?> GetByIdAsync(int id)
        {
            var f = await _repository.GetByIdAsync(id);
            if (f == null) return null;

            return new FeedbackDto
            {
                Id = f.Id,
                IdColaborador = f.IdColaborador,
                IdLider = f.IdLider,
                IdTipoFeedback = f.IdTipoFeedback,
                Observacoes = f.Observacoes,
                Data = f.Data,
                Percepcao = f.Percepcao,
                PlanoAcao = f.PlanoAcao,
                ColaboradorId = f.ColaboradorId,
                TipoFeedbackId = f.TipoFeedbackId,
                NomeColaborador = f.Colaborador?.Nome,
                TipoFeedbackDescricao = f.TipoFeedback?.Tipo
            };
        }

        public async Task AddAsync(FeedbackDto dto)
        {
            var f = new Feedback
            {
                IdColaborador = dto.IdColaborador,
                IdLider = dto.IdLider,
                IdTipoFeedback = dto.IdTipoFeedback,
                Observacoes = dto.Observacoes,
                Data = dto.Data,
                Percepcao = dto.Percepcao,
                PlanoAcao = dto.PlanoAcao,
                ColaboradorId = dto.ColaboradorId,
                TipoFeedbackId = dto.TipoFeedbackId
            };

            await _repository.AddAsync(f);
        }

        public async Task UpdateAsync(FeedbackDto dto)
        {
            var f = await _repository.GetByIdAsync(dto.Id);
            if (f == null) return;

            f.IdColaborador = dto.IdColaborador;
            f.IdLider = dto.IdLider;
            f.IdTipoFeedback = dto.IdTipoFeedback;
            f.Observacoes = dto.Observacoes;
            f.Data = dto.Data;
            f.Percepcao = dto.Percepcao;
            f.PlanoAcao = dto.PlanoAcao;
            f.ColaboradorId = dto.ColaboradorId;
            f.TipoFeedbackId = dto.TipoFeedbackId;

            await _repository.UpdateAsync(f);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<PagedResult<FeedbackDto>> ListarPaginadoAsync(int page, int pageSize)
        {
            var total = await _repository.ContarAsync();
            var feedbacks = await _repository.ListarPaginadoAsync(page, pageSize);

            var dtos = feedbacks.Select(f => new FeedbackDto
            {
                Id = f.Id,
                IdColaborador = f.IdColaborador,
                IdLider = f.IdLider,
                IdTipoFeedback = f.IdTipoFeedback,
                Observacoes = f.Observacoes,
                Data = f.Data,
                Percepcao = f.Percepcao,
                PlanoAcao = f.PlanoAcao,
                ColaboradorId = f.ColaboradorId,
                TipoFeedbackId = f.TipoFeedbackId,
                NomeColaborador = f.Colaborador?.Nome,
                TipoFeedbackDescricao = f.TipoFeedback?.Tipo
            });

            return new PagedResult<FeedbackDto>(dtos, total, page, pageSize);
        }

    }
}
