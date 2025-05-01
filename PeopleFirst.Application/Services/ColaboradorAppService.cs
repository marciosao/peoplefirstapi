using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;
using PeopleFirst.Domain.Entities;
using PeopleFirst.Domain.Interfaces;

namespace PeopleFirst.Application.Services
{
    public class ColaboradorAppService : IColaboradorAppService
    {
        private readonly IColaboradorRepository _repository;
        private readonly IPerfilRepository _perfilRepository;

        public ColaboradorAppService(IColaboradorRepository repository, IPerfilRepository perfilRepository)
        {
            _repository = repository;
            _perfilRepository = perfilRepository;
        }

        public async Task<IEnumerable<ColaboradorDto>> GetAllAsync()
        {
            var colaboradores = await _repository.GetAllAsync();
            return colaboradores.Select(c => new ColaboradorDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                SenhaHash = c.SenhaHash,
                DataNascimento = c.DataNascimento,
                Cargo = c.Cargo,
                Ativo = c.Ativo,
                Foto = c.Foto,
                PerfilId = c.PerfilId,
                PerfilNome = c.Perfil?.PerfilNome
            });
        }

        public async Task<ColaboradorDto?> GetByIdAsync(int id)
        {
            var c = await _repository.GetByIdAsync(id);
            if (c == null) return null;

            return new ColaboradorDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                SenhaHash = c.SenhaHash,
                DataNascimento = c.DataNascimento,
                Cargo = c.Cargo,
                Ativo = c.Ativo,
                Foto = c.Foto,
                PerfilId = c.PerfilId,
                PerfilNome = c.Perfil?.PerfilNome
            };
        }

        public async Task AddAsync(ColaboradorDto dto)
        {
            var colaborador = new Colaborador
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = dto.SenhaHash,
                DataNascimento = dto.DataNascimento,
                Cargo = dto.Cargo,
                Ativo = dto.Ativo,
                Foto = dto.Foto,
                PerfilId = dto.PerfilId
            };

            await _repository.AddAsync(colaborador);
        }

        public async Task UpdateAsync(ColaboradorDto dto)
        {
            var colaborador = await _repository.GetByIdAsync(dto.Id);
            if (colaborador == null) return;

            colaborador.Nome = dto.Nome;
            colaborador.Email = dto.Email;
            colaborador.SenhaHash = dto.SenhaHash;
            colaborador.DataNascimento = dto.DataNascimento;
            colaborador.Cargo = dto.Cargo;
            colaborador.Ativo = dto.Ativo;
            colaborador.Foto = dto.Foto;
            colaborador.PerfilId = dto.PerfilId;

            await _repository.UpdateAsync(colaborador);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ColaboradorDto?> BuscarPorEmail(string email)
        {
            var c = await _repository.BuscarPorEmail(email);
            if (c == null) return null;

            return new ColaboradorDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Email = c.Email,
                SenhaHash = c.SenhaHash,
                DataNascimento = c.DataNascimento,
                Cargo = c.Cargo,
                Ativo = c.Ativo,
                Foto = c.Foto,
                PerfilId = c.PerfilId,
                PerfilNome = c.Perfil?.PerfilNome
            };
        }

    }
}
