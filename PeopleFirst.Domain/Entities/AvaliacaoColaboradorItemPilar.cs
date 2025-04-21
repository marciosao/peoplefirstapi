namespace PeopleFirst.Domain.Entities
{
    public class AvaliacaoColaboradorItemPilar
    {
        public int Id { get; set; }

        public int? IdAvaliacaoColaborador { get; set; }
        public int? IdItemPilar { get; set; }
        public decimal? Nota { get; set; }

        public int AvaliacaoColaboradorId { get; set; }
        public int ItemPilarId { get; set; }

        // Navegação
        public AvaliacaoColaborador AvaliacaoColaborador { get; set; } = null!;
        public ItemPilar ItemPilar { get; set; } = null!;
    }
}
