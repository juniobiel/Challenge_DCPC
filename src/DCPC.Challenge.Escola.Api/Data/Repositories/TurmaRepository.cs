using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DCPC.Challenge.Escola.Api.Data.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(ApplicationDbContext db) : base(db) { }

        public Task<Turma> GetWithCursoProfessorAsync(Guid id, CancellationToken ct)
            => _db.Turmas
                .Include(t => t.Curso)
                .Include(t => t.Professor)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id, ct);
    }
}