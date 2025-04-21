namespace PeopleFirst.Application.DTOs
{
    public class AvaliacaoColaboradorItemPilarDto
    {
        public int Id { get; set; }
        public int? IdAvaliacaoColaborador { get; set; }
        public int? IdItemPilar { get; set; }
        public decimal? Nota { get; set; }

        public int AvaliacaoColaboradorId { get; set; }
        public int ItemPilarId { get; set; }

        public string? NomeItemPilar { get; set; }
        public string? NomeColaborador { get; set; }
    }
}
