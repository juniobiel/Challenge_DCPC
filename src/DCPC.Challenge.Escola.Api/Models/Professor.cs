namespace DCPC.Challenge.Escola.Api.Models
{
    public class Professor : Entity
    {
        public string Nome { get; set; } = default!;
        public string? Email { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}