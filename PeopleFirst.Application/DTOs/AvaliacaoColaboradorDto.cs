namespace PeopleFirst.Application.DTOs
{
    public class AvaliacaoColaboradorDto
    {
        public int Id { get; set; }
        public int? IdColaborador { get; set; }
        public int? IdLider { get; set; }
        public DateTime? Data { get; set; }
        public string? Percepcao { get; set; }
        public string? ComentarioGeral { get; set; }
        public string? PlanoAcao { get; set; }
        public string? AvaliacaoColaboradorCol { get; set; }
        public bool? Finalizada { get; set; }

        public int ColaboradorId { get; set; }
        public string? NomeColaborador { get; set; } // Para exibir
    }
}
