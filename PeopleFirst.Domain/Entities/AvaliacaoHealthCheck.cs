namespace PeopleFirst.Domain.Entities
{
    public class AvaliacaoHealthCheck
    {
        public int Id { get; set; }

        public int HealthCheckId { get; set; }
        public int TimeId { get; set; }

        public int QuestaoPilarId { get; set; }
        public int PilarDominioId { get; set; }
        public int DominioAgilidadeId { get; set; }

        public decimal? NotaFinal { get; set; }
        public string? Observacoes { get; set; }

        // Navegação
        public HealthCheck? HealthCheck { get; set; }
        public QuestaoPilar? QuestaoPilar { get; set; }
    }
}
