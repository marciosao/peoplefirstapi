namespace PeopleFirst.Application.DTOs
{
    public class ItemPilarDto
    {
        public int Id { get; set; }
        public string? Item { get; set; }
        public string? Descricao { get; set; }
        public int IdPilarCompetencia { get; set; }

        public string? NomePilar { get; set; }
    }
}
