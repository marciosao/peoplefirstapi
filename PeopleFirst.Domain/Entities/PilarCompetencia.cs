namespace PeopleFirst.Domain.Entities
{
    public class PilarCompetencia
    {
        public int Id { get; set; }
        public string? Pilar { get; set; }
        public string? Descricao { get; set; }

// Novos relacionamentos
        public int PerfilId { get; set; }
        public Perfil? Perfil { get; set; }

        public int TipoCompetenciaId { get; set; }
        public TipoCompetencia? TipoCompetencia { get; set; }

        public ICollection<ItemPilar>? Itens { get; set; }
    }
}
