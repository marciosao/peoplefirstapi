namespace PeopleFirst.Domain.Entities
{
    public class ItemPilar
    {
        public int Id { get; set; }
        public string? Item { get; set; }
        public string? Descricao { get; set; }

        // Chave estrangeira
        public int PilarCompetenciaId { get; set; }

        // Navegação
        public PilarCompetencia PilarCompetencia { get; set; } = null!;
    }
}
