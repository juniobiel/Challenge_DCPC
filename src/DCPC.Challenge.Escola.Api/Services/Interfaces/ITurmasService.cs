using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces
{
    public interface ITurmasService
    {
        Task<IEnumerable<Turma>> ListarAsync();
        Task<Turma?> ObterPorIdAsync(Guid id);
        Task<Turma> RegistrarTurma(Turma turma);
        Task AtualizarTurmaAsync(Turma turma);
        Task<bool> RemoverTurmaAsync(Guid id);
    }
}