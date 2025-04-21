namespace PeopleFirst.Application.DTOs
{
    public class AvaliacaoHealthCheckDto
    {
        public int Id { get; set; }

        public int HealthCheckId { get; set; }
        public int TimeId { get; set; }

        public int QuestaoPilarId { get; set; }
        public int PilarDominioId { get; set; }
        public int DominioAgilidadeId { get; set; }

        public decimal? NotaFinal { get; set; }
        public string? Observacoes { get; set; }
    }
}
