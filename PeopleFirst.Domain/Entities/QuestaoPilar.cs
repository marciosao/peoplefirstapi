namespace PeopleFirst.Domain.Entities
{
    public class QuestaoPilar
    {
        public int Id { get; set; }
        public string? Questao { get; set; }

        // Chaves estrangeiras
        public int PilarDominioId { get; set; }
        public int DominioAgilidadeId { get; set; }

        // Navegação
        public PilarDominio? PilarDominio { get; set; }
        public ICollection<AvaliacaoHealthCheck>? Avaliacoes { get; set; }
    }
}
