using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DCPC.Challenge.Escola.Api.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationDbContext db) : base(db) { }

        public Task<Aluno> GetWithMatriculasAsync(Guid id)
            => _db.Alunos
                .Include(a => a.Matriculas)
                    .ThenInclude(m => m.Turma)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
    }
}