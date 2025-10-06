using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DCPC.Challenge.Escola.Api.Data.Repositories
{
    public class NotaRepository : Repository<Nota>, INotaRepository
    {
        public NotaRepository(ApplicationDbContext db) : base(db) { }

        public Task<List<Nota>> ListByMatriculaAsync(Guid matriculaId, CancellationToken ct)
            => _db.Notas
                .Where(n => n.MatriculaId == matriculaId)
                .AsNoTracking()
                .ToListAsync(ct);
    }
}