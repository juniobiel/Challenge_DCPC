using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Services
{
    public class CursosService : ICursosService
    {
        private readonly ICursoRepository _repository;
        private readonly ApplicationDbContext _db;

        public CursosService(ICursoRepository repository, ApplicationDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<Curso>> ListarAsync()
            => await _repository.ListAsync();

        public Task<Curso?> ObterPorIdAsync(Guid id)
            => _repository.GetByIdAsync(id);

        public async Task<Curso> RegistrarCurso(Curso curso)
        {
            if (curso.Id == default) curso.Id = Guid.NewGuid();
            await _repository.AddAsync(curso);
            await _db.SaveChangesAsync();
            return curso;
        }

        public async Task AtualizarCursoAsync(Curso curso)
        {
            _repository.Update(curso);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoverCursoAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}