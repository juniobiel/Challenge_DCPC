using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno> GetWithMatriculasAsync(Guid id, CancellationToken ct);
    }
}