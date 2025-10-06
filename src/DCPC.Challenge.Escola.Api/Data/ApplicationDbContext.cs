using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DCPC.Challenge.Escola.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            // Índice único: um aluno não pode se matricular duas vezes na mesma turma
            modelBuilder.Entity<Matricula>()
                .HasIndex(m => new { m.AlunoId, m.TurmaId })
                .IsUnique();

            // IDs fixos para manter relacionamentos no seed
            var cursoProgId = Guid.Parse("f2f9f3b3-8f55-4f1f-9f7b-2f2b3f9a1a01");
            var cursoMathId = Guid.Parse("7b4a9d1e-0f4a-4f4e-9b13-0b5f3b7d2a02");

            var profAnaId = Guid.Parse("a1c2d3e4-f5a6-47b8-9c0d-1e2f3a4b5c03");
            var profBetoId = Guid.Parse("0f1e2d3c-4b5a-6978-9a0b-1c2d3e4f5a04");

            var alunoJoaoId = Guid.Parse("11111111-2222-3333-4444-555555555501");
            var alunoMariaId = Guid.Parse("11111111-2222-3333-4444-555555555502");
            var alunoLiaId = Guid.Parse("11111111-2222-3333-4444-555555555503");

            var turmaProg2025Id = Guid.Parse("22222222-3333-4444-5555-666666666601");
            var turmaMath2025Id = Guid.Parse("22222222-3333-4444-5555-666666666602");
            var turmaProgNoiteId = Guid.Parse("22222222-3333-4444-5555-666666666603");

            var mat1Id = Guid.Parse("33333333-4444-5555-6666-777777777701");
            var mat2Id = Guid.Parse("33333333-4444-5555-6666-777777777702");
            var mat3Id = Guid.Parse("33333333-4444-5555-6666-777777777703");
            var mat4Id = Guid.Parse("33333333-4444-5555-6666-777777777704");

            var nota1Id = Guid.Parse("44444444-5555-6666-7777-888888888801");
            var nota2Id = Guid.Parse("44444444-5555-6666-7777-888888888802");
            var nota3Id = Guid.Parse("44444444-5555-6666-7777-888888888803");
            var nota4Id = Guid.Parse("44444444-5555-6666-7777-888888888804");

            // Cursos
            modelBuilder.Entity<Curso>().HasData(
                new Curso { Id = cursoProgId, Nome = ".NET Fundamentals", CargaHoraria = 80 },
                new Curso { Id = cursoMathId, Nome = "Matemática Básica", CargaHoraria = 60 }
            );

            // Professores
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = profAnaId, Nome = "Ana Souza", Email = "ana.souza@escola.com" },
                new Professor { Id = profBetoId, Nome = "Roberto Lima", Email = "roberto.lima@escola.com" }
            );

            // Alunos
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { Id = alunoJoaoId, Nome = "João Silva", Email = "joao.silva@email.com", DataNascimento = new DateOnly(2007, 1, 15), Ativo = true },
                new Aluno { Id = alunoMariaId, Nome = "Maria Oliveira", Email = "maria.oliveira@email.com", DataNascimento = new DateOnly(2006, 6, 20), Ativo = true },
                new Aluno { Id = alunoLiaId, Nome = "Lia Santos", Email = "lia.santos@email.com", DataNascimento = new DateOnly(2005, 11, 5), Ativo = true }
            );

            // Turmas
            modelBuilder.Entity<Turma>().HasData(
                new Turma { Id = turmaProg2025Id, Nome = "Prog Manhã 2025", AnoLetivo = 2025, Semestre = 1, CursoId = cursoProgId, ProfessorId = profAnaId },
                new Turma { Id = turmaMath2025Id, Nome = "Math Tarde 2025", AnoLetivo = 2025, Semestre = 1, CursoId = cursoMathId, ProfessorId = profBetoId },
                new Turma { Id = turmaProgNoiteId, Nome = "Prog Noite 2025", AnoLetivo = 2025, Semestre = 2, CursoId = cursoProgId, ProfessorId = profBetoId }
            );

            // Matrículas
            modelBuilder.Entity<Matricula>().HasData(
                new Matricula { Id = mat1Id, AlunoId = alunoJoaoId, TurmaId = turmaProg2025Id, DataMatricula = new DateOnly(2025, 2, 10), Status = MatriculaStatus.Ativa },
                new Matricula { Id = mat2Id, AlunoId = alunoMariaId, TurmaId = turmaProg2025Id, DataMatricula = new DateOnly(2025, 2, 12), Status = MatriculaStatus.Ativa },
                new Matricula { Id = mat3Id, AlunoId = alunoMariaId, TurmaId = turmaMath2025Id, DataMatricula = new DateOnly(2025, 2, 15), Status = MatriculaStatus.Ativa },
                new Matricula { Id = mat4Id, AlunoId = alunoLiaId, TurmaId = turmaMath2025Id, DataMatricula = new DateOnly(2025, 2, 18), Status = MatriculaStatus.Ativa }
            );

            // Notas
            modelBuilder.Entity<Nota>().HasData(
                new Nota { Id = nota1Id, MatriculaId = mat1Id, Avaliacao = "Prova 1", Valor = 8.5m, Data = new DateOnly(2025, 3, 10) },
                new Nota { Id = nota2Id, MatriculaId = mat1Id, Avaliacao = "Prova 2", Valor = 7.0m, Data = new DateOnly(2025, 4, 5) },
                new Nota { Id = nota3Id, MatriculaId = mat2Id, Avaliacao = "Prova 1", Valor = 9.2m, Data = new DateOnly(2025, 3, 10) },
                new Nota { Id = nota4Id, MatriculaId = mat3Id, Avaliacao = "Trabalho 1", Valor = 10.0m, Data = new DateOnly(2025, 3, 25) }
            );
        }
    }
}
