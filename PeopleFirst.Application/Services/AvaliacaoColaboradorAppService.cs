using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class AvaliacaoColaboradorAppService : IAvaliacaoColaboradorAppService
    {
        private readonly IAvaliacaoColaboradorRepository _repository;
        private readonly IColaboradorRepository _colaboradorRepository;

        public AvaliacaoColaboradorAppService(
            IAvaliacaoColaboradorRepository repository,
            IColaboradorRepository colaboradorRepository)
        {
            _repository = repository;
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<IEnumerable<AvaliacaoColaboradorDto>> GetAllAsync()
        {
            var avaliacoes = await _repository.GetAllAsync();

            return avaliacoes.Select(a => new AvaliacaoColaboradorDto
            {
                Id = a.Id,
                IdColaborador = a.IdColaborador,
                IdLider = a.IdLider,
                Data = a.Data,
                Percepcao = a.Percepcao,
                ComentarioGeral = a.ComentarioGeral,
                PlanoAcao = a.PlanoAcao,
                AvaliacaoColaboradorCol = a.AvaliacaoColaboradorCol,
                Finalizada = a.Finalizada,
                ColaboradorId = a.ColaboradorId,
                NomeColaborador = a.Colaborador?.Nome
            });
        }

        public async Task<AvaliacaoColaboradorDto?> GetByIdAsync(int id)
        {
            var a = await _repository.GetByIdAsync(id);
            if (a == null) return null;

            return new AvaliacaoColaboradorDto
            {
                Id = a.Id,
                IdColaborador = a.IdColaborador,
                IdLider = a.IdLider,
                Data = a.Data,
                Percepcao = a.Percepcao,
                ComentarioGeral = a.ComentarioGeral,
                PlanoAcao = a.PlanoAcao,
                AvaliacaoColaboradorCol = a.AvaliacaoColaboradorCol,
                Finalizada = a.Finalizada,
                ColaboradorId = a.ColaboradorId,
                NomeColaborador = a.Colaborador?.Nome
            };
        }

        public async Task AddAsync(AvaliacaoColaboradorDto dto)
        {
            var avaliacao = new AvaliacaoColaborador
            {
                IdColaborador = dto.IdColaborador,
                IdLider = dto.IdLider,
                Data = dto.Data,
                Percepcao = dto.Percepcao,
                ComentarioGeral = dto.ComentarioGeral,
                PlanoAcao = dto.PlanoAcao,
                AvaliacaoColaboradorCol = dto.AvaliacaoColaboradorCol,
                Finalizada = dto.Finalizada,
                ColaboradorId = dto.ColaboradorId
            };

            await _repository.AddAsync(avaliacao);
        }

        public async Task UpdateAsync(AvaliacaoColaboradorDto dto)
        {
            var avaliacao = await _repository.GetByIdAsync(dto.Id);
            if (avaliacao == null) return;

            avaliacao.IdColaborador = dto.IdColaborador;
            avaliacao.IdLider = dto.IdLider;
            avaliacao.Data = dto.Data;
            avaliacao.Percepcao = dto.Percepcao;
            avaliacao.ComentarioGeral = dto.ComentarioGeral;
            avaliacao.PlanoAcao = dto.PlanoAcao;
            avaliacao.AvaliacaoColaboradorCol = dto.AvaliacaoColaboradorCol;
            avaliacao.Finalizada = dto.Finalizada;
            avaliacao.ColaboradorId = dto.ColaboradorId;

            await _repository.UpdateAsync(avaliacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
