namespace PeopleFirst.Application.DTOs
{
    public class PilarCompetenciaDto
    {
        public int Id { get; set; }
        public string? Pilar { get; set; }
        public string? Descricao { get; set; }
        public int TipoCompetenciaPerfilId { get; set; }
        public int PerfilId { get; set; }
        public string? PerfilNome { get; set; }
        public int TipoCompetenciaId { get; set; }
        public string? TipoCompetenciaNome { get; set; }

    }
}
