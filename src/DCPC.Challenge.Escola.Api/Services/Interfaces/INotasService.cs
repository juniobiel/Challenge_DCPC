using DCPC.Challenge.Escola.Api.Models;

namespace DCPC.Challenge.Escola.Api.Services.Interfaces
{
    public interface INotasService
    {
        Task<IEnumerable<Nota>> ListarAsync();
        Task<Nota?> ObterPorIdAsync(Guid id);
        Task<Nota> RegistrarNota(Nota nota);
        Task AtualizarNotaAsync(Nota nota);
        Task<bool> RemoverNotaAsync(Guid id);
    }
}