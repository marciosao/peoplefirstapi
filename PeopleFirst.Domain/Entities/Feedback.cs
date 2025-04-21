namespace PeopleFirst.Domain.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        public int IdColaborador { get; set; }
        public int IdLider { get; set; }
        public int? IdTipoFeedback { get; set; }
        public string? Observacoes { get; set; }
        public DateTime? Data { get; set; }
        public string? Percepcao { get; set; }
        public string? PlanoAcao { get; set; }

        public int ColaboradorId { get; set; }
        public int TipoFeedbackId { get; set; }

        // Navegação
        public Colaborador Colaborador { get; set; } = null!;
        public TipoFeedback TipoFeedback { get; set; } = null!;
    }
}
