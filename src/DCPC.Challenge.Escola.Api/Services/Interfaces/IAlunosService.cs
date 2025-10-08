using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces
{
    public interface IAlunosService
    {
        Task<IEnumerable<Aluno>> ListarAsync();
        Task<Aluno?> ObterPorIdAsync(Guid id);
        Task<Aluno?> ObterComMatriculasAsync(Guid id);
        Task<Aluno> RegistrarAluno(Aluno aluno);
        Task AtualizarAlunoAsync(Aluno aluno);
        Task<bool> RemoverAlunoAsync(Guid id);
    }
}
