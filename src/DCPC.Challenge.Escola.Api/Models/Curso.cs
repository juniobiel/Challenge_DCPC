namespace DCPC.Challenge.Escola.Api.Models
{
    public class Curso : Entity
    {
        public string Nome { get; set; } = default!;
        public int CargaHoraria { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
    }
}