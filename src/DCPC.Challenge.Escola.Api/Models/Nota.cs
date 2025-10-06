namespace DCPC.Challenge.Escola.Api.Models
{
    public class Nota : Entity
    {
        public Guid MatriculaId { get; set; }
        public Matricula Matricula { get; set; } = default!;

        public string Avaliacao { get; set; } = default!; // ex.: "Prova 1"
        public decimal Valor { get; set; }                // ex.: 0-10
        public DateOnly Data { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}