namespace PeopleFirst.Domain.Entities
{
    public class TimeColaborador
    {
        public int Id { get; set; }

        public int? IdTime { get; set; }
        public int? IdColaborador { get; set; }

        public int TimeId { get; set; }
        public int ColaboradorId { get; set; }

        // Navegação
        public Time Time { get; set; } = null!;
        public Colaborador Colaborador { get; set; } = null!;
    }
}
