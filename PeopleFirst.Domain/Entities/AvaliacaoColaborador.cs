namespace PeopleFirst.Domain.Entities
{
    public class AvaliacaoColaborador
    {
        public int Id { get; set; }
        public int? IdColaborador { get; set; } // Campo solto
        public int? IdLider { get; set; }
        public DateTime? Data { get; set; }
        public string? Percepcao { get; set; }
        public string? ComentarioGeral { get; set; }
        public string? PlanoAcao { get; set; }
        public string? AvaliacaoColaboradorCol { get; set; }
        public bool? Finalizada { get; set; }

        // FK obrigatória
        public int ColaboradorId { get; set; }

        // Navegação
        public Colaborador Colaborador { get; set; } = null!;
    }
}
