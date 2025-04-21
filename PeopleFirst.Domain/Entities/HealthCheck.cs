namespace PeopleFirst.Domain.Entities
{
    public class HealthCheck
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        public int? IdFacilitador { get; set; }

        public DateTime? DataExecucao { get; set; }
        public decimal? NotaGeral { get; set; }
        public string? ConsideracoesFinais { get; set; }

        // Navegação
        public Time? Time { get; set; }
        public ICollection<AvaliacaoHealthCheck>? Avaliacoes { get; set; }
    }
}
