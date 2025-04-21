namespace PeopleFirst.Domain.Entities
{
    public class OpiniaoPilarHappiness
    {
        public int Id { get; set; }
        public int? IdHappiness { get; set; }
        public int? IdPilarHappiness { get; set; }
        public decimal? Nota { get; set; }
        public string? Comentario { get; set; }

        public int HappinessId { get; set; }
        public int PilarHappinessId { get; set; }

        // Navegação
        public Happiness Happiness { get; set; } = null!;
        public PilarHappiness PilarHappiness { get; set; } = null!;
    }
}
