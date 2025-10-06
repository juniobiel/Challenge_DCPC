using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces
{
    public interface INotaRepository : IRepository<Nota>
    {
        Task<List<Nota>> ListByMatriculaAsync(Guid matriculaId, CancellationToken ct);
    }
}