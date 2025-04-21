namespace PeopleFirst.Application.DTOs
{
    public class TimeColaboradorDto
    {
        public int Id { get; set; }
        public int? IdTime { get; set; }
        public int? IdColaborador { get; set; }
        public int TimeId { get; set; }
        public int ColaboradorId { get; set; }

        public string? NomeTime { get; set; }
        public string? NomeColaborador { get; set; }
    }
}
