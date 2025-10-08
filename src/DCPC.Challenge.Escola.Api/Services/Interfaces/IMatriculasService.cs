using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces
{
    public interface IMatriculasService
    {
        Task<IEnumerable<Matricula>> ListarAsync();
        Task<Matricula?> ObterPorIdAsync(Guid id);
        Task<Matricula> RegistrarMatricula(Matricula matricula);
        Task AtualizarMatriculaAsync(Matricula matricula);
        Task<bool> RemoverMatriculaAsync(Guid id);
    }
}