namespace PeopleFirst.Application.DTOs
{
    public class QuestaoPilarDto
    {
        public int Id { get; set; }
        public string? Questao { get; set; }

        public int PilarDominioId { get; set; }
        public int DominioAgilidadeId { get; set; }
    }
}
