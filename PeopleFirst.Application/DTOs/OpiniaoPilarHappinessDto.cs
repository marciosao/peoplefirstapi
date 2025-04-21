namespace PeopleFirst.Application.DTOs
{
    public class OpiniaoPilarHappinessDto
    {
        public int Id { get; set; }
        public int? IdHappiness { get; set; }
        public int? IdPilarHappiness { get; set; }
        public decimal? Nota { get; set; }
        public string? Comentario { get; set; }

        public int HappinessId { get; set; }
        public int PilarHappinessId { get; set; }

        public string? NomePilar { get; set; }
    }
}
