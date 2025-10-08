using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces
{
    public interface ICursosService
    {
        Task<IEnumerable<Curso>> ListarAsync();
        Task<Curso?> ObterPorIdAsync(Guid id);
        Task<Curso> RegistrarCurso(Curso curso);
        Task AtualizarCursoAsync(Curso curso);
        Task<bool> RemoverCursoAsync(Guid id);
    }
}