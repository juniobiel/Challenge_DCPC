using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;

namespace DCPC.Challenge.Escola.Api.Services
{
    public class AlunosService : IAlunosService
    {
        private readonly IAlunoRepository _repository;
        private readonly ApplicationDbContext _db;

        public AlunosService(IAlunoRepository alunoRepository, ApplicationDbContext db)
        {
            _repository = alunoRepository;
            _db = db;
        }

        public async Task<IEnumerable<Aluno>> ListarAsync()
            => await _repository.ListAsync();

        public Task<Aluno> ObterPorIdAsync(Guid id)
            => _repository.GetByIdAsync(id );

        public Task<Aluno> ObterComMatriculasAsync(Guid id)
            => _repository.GetWithMatriculasAsync(id);

        public async Task<Aluno> RegistrarAluno(Aluno aluno)
        {
            if (aluno.Id == default) aluno.Id = Guid.NewGuid();
            await _repository.AddAsync(aluno );
            await _db.SaveChangesAsync();
            return aluno;
        }

        public async Task AtualizarAlunoAsync(Aluno aluno)
        {
            _repository.Update(aluno);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> RemoverAlunoAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id );
            if (entity is null) return false;

            _repository.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
