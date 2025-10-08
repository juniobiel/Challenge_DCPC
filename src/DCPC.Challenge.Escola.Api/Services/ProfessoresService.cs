using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Services
{
    public class ProfessoresService : IProfessoresService
    {
        private readonly IProfessorRepository _repository;
        private readonly ApplicationDbContext _db;

        public ProfessoresService(IProfessorRepository repository, ApplicationDbContext db)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<IEnumerable<Professor>> ListarAsync()
            => await _repository.ListAsync();

        public Task<Professor?> ObterPorIdAsync(Guid id)
            => _repository.GetByIdAsync(id);

        public async Task<Professor> RegistrarProfessor(Professor professor)
        {
            if (professor.Id == default) professor.Id = Guid.NewGuid();
            await _repository.AddAsync(professor);
            await _db.SaveChangesAsync();
            return professor;
        }

        public async Task AtualizarProfessorAsync(Professor professor)
        {
            _repository.Update(professor);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoverProfessorAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}