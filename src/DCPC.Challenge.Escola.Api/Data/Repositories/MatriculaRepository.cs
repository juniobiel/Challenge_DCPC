using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DCPC.Challenge.Escola.Api.Data.Repositories
{
    public class MatriculaRepository : Repository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(ApplicationDbContext db) : base(db) { }

        public Task<Matricula> GetWithAlunoTurmaNotasAsync(Guid id, CancellationToken ct)
            => _db.Matriculas
                .Include(m => m.Aluno)
                .Include(m => m.Turma)
                    .ThenInclude(t => t.Curso)
                .Include(m => m.Notas)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id, ct);

        public Task<List<Matricula>> ListByAlunoAsync(Guid alunoId, CancellationToken ct)
            => _db.Matriculas
                .Where(m => m.AlunoId == alunoId)
                .Include(m => m.Turma)
                .AsNoTracking()
                .ToListAsync(ct);
    }
}