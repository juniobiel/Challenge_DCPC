using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces
{
    public interface IProfessoresService
    {
        Task<IEnumerable<Professor>> ListarAsync();
        Task<Professor?> ObterPorIdAsync(Guid id);
        Task<Professor> RegistrarProfessor(Professor professor);
        Task AtualizarProfessorAsync(Professor professor);
        Task<bool> RemoverProfessorAsync(Guid id);
    }
}