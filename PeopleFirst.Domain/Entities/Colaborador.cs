namespace PeopleFirst.Domain.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } // Armazena o hash da senha
        public DateTime? DataNascimento { get; set; }
        public string? Cargo { get; set; }
        public bool? Ativo { get; set; }
        public byte[]? Foto { get; set; }

        // FK
        public int PerfilId { get; set; }

        // Navegação
        public Perfil Perfil { get; set; } = null!;
    }
}
