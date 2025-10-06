using DCPC.Challenge.Escola.Api.Models.Enums;

namespace DCPC.Challenge.Escola.Api.Models
{
    public class Matricula : Entity
    {
        public Guid AlunoId { get; set; }
        public Aluno Aluno { get; set; } = default!;

        public Guid TurmaId { get; set; }
        public Turma Turma { get; set; } = default!;

        public DateOnly DataMatricula { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public MatriculaStatus Status { get; set; } = MatriculaStatus.Ativa;

        public ICollection<Nota> Notas { get; set; } = new List<Nota>();
    }
}