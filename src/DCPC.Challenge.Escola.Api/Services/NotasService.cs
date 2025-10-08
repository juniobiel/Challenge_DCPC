using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Services
{
    public class NotasService : INotasService
    {
        private readonly INotaRepository _repository;
        private readonly ApplicationDbContext _db;

        public NotasService(INotaRepository repository, ApplicationDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<Nota>> ListarAsync()
            => await _repository.ListAsync();

        public Task<Nota?> ObterPorIdAsync(Guid id)
            => _repository.GetByIdAsync(id);

        public async Task<Nota> RegistrarNota(Nota nota)
        {
            if (nota.Id == default) nota.Id = Guid.NewGuid();
            await _repository.AddAsync(nota);
            await _db.SaveChangesAsync();
            return nota;
        }

        public async Task AtualizarNotaAsync(Nota nota)
        {
            _repository.Update(nota);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoverNotaAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}