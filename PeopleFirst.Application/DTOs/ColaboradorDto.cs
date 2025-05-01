namespace PeopleFirst.Application.DTOs
{
    public class ColaboradorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; }  = string.Empty;
        public DateTime? DataNascimento { get; set; }
        public string? Cargo { get; set; }
        public bool? Ativo { get; set; }
        public byte[]? Foto { get; set; }

        public int PerfilId { get; set; }
        public string? PerfilNome { get; set; }  // Usado para exibir dados do perfil associado
    }
}
