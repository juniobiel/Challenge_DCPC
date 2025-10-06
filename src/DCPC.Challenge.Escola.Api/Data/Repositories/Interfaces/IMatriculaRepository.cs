using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces
{
    public interface IMatriculaRepository : IRepository<Matricula>
    {
        Task<Matricula> GetWithAlunoTurmaNotasAsync(Guid id, CancellationToken ct);
        Task<List<Matricula>> ListByAlunoAsync(Guid alunoId, CancellationToken ct);
    }
}