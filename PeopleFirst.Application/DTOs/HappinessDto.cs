namespace PeopleFirst.Application.DTOs
{
    public class HappinessDto
    {
        public int Id { get; set; }
        public int? IdColaborador { get; set; }
        public DateTime? Data { get; set; }
        public decimal? NotaGeral { get; set; }
        public string? AvaliacaoGeral { get; set; }

        public int ColaboradorId { get; set; }
        public int ColaboradorPerfilId { get; set; }

        public string? NomeColaborador { get; set; }
    }
}
