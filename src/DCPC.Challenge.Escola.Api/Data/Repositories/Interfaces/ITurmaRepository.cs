using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces
{
    public interface ITurmaRepository : IRepository<Turma>
    {
        Task<Turma> GetWithCursoProfessorAsync(Guid id, CancellationToken ct);
    }
}