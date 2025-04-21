namespace PeopleFirst.Application.DTOs
{
    public class HealthCheckDto
    {
        public int Id { get; set; }
        public int TimeId { get; set; }
        public int? IdFacilitador { get; set; }
        public DateTime? DataExecucao { get; set; }
        public decimal? NotaGeral { get; set; }
        public string? ConsideracoesFinais { get; set; }
    }
}
