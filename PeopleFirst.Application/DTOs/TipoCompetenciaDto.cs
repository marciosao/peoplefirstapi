namespace PeopleFirst.Application.DTOs
{
    public class TipoCompetenciaDto
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }            // COMPORTAMENTAL ou TÉCNICA
        //public string? TipoCompetenciaCol { get; set; }  // Campo alternativo (exibição, codificação, etc.)
    }
}
