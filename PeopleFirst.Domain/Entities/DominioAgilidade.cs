namespace PeopleFirst.Domain.Entities
{
    public class DominioAgilidade
    {
        public int Id { get; set; }
        public string? Dominio { get; set; }

        // Navegação
        public ICollection<PilarDominio>? PilarDominios { get; set; }
    }
}
