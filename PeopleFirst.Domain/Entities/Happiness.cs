namespace PeopleFirst.Domain.Entities
{
    public class Happiness
    {
        public int Id { get; set; }
        public int? IdColaborador { get; set; }
        public DateTime? Data { get; set; }
        public decimal? NotaGeral { get; set; }
        public string? AvaliacaoGeral { get; set; }

        public int ColaboradorId { get; set; }
        public int ColaboradorPerfilId { get; set; }

        // Navegação
        public Colaborador Colaborador { get; set; } = null!;
    }
}
