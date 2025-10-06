namespace DCPC.Challenge.Escola.Api.Models
{
    public class Turma : Entity
    {
        public string Nome { get; set; } = default!;
        public int AnoLetivo { get; set; }
        public int Semestre { get; set; }

        public Guid CursoId { get; set; }
        public Curso Curso { get; set; } = default!;

        public Guid? ProfessorId { get; set; }
        public Professor? Professor { get; set; }

        public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}