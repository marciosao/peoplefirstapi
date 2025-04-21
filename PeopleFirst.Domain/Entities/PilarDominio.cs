namespace PeopleFirst.Domain.Entities
{
    public class PilarDominio
    {
        public int Id { get; set; }
        public string Pilar { get; set; } = string.Empty;

        // Chave estrangeira
        public int DominioAgilidadeId { get; set; }

        // Navegação
        public DominioAgilidade? DominioAgilidade { get; set; }
        public ICollection<QuestaoPilar>? Questoes { get; set; }
    }
}
