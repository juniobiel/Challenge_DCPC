namespace DCPC.Challenge.Escola.Api.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; } = default!;
        public DateOnly DataNascimento { get; set; }
        public string? Email { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
