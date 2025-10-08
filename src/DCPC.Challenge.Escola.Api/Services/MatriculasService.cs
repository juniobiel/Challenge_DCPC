using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Services
{
    public class MatriculasService : IMatriculasService
    {
        private readonly IMatriculaRepository _repository;
        private readonly ApplicationDbContext _db;

        public MatriculasService(IMatriculaRepository repository, ApplicationDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<Matricula>> ListarAsync()
            => await _repository.ListAsync();

        public Task<Matricula?> ObterPorIdAsync(Guid id)
            => _repository.GetByIdAsync(id);

        public async Task<Matricula> RegistrarMatricula(Matricula matricula)
        {
            if (matricula.Id == default) matricula.Id = Guid.NewGuid();
            await _repository.AddAsync(matricula);
            await _db.SaveChangesAsync();
            return matricula;
        }

        public async Task AtualizarMatriculaAsync(Matricula matricula)
        {
            _repository.Update(matricula);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoverMatriculaAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}