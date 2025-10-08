using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Services
{
    public class TurmasService : ITurmasService
    {
        private readonly ITurmaRepository _repository;
        private readonly ApplicationDbContext _db;

        public TurmasService(ITurmaRepository repository, ApplicationDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<Turma>> ListarAsync()
            => await _repository.ListAsync();

        public Task<Turma?> ObterPorIdAsync(Guid id)
            => _repository.GetByIdAsync(id);

        public async Task<Turma> RegistrarTurma(Turma turma)
        {
            if (turma.Id == default) turma.Id = Guid.NewGuid();
            await _repository.AddAsync(turma);
            await _db.SaveChangesAsync();
            return turma;
        }

        public async Task AtualizarTurmaAsync(Turma turma)
        {
            _repository.Update(turma);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoverTurmaAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}