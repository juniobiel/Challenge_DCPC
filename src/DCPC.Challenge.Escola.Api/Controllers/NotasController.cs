using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Route("api/notas")]
    public class NotasController : ControllerBase
    {
        private readonly INotaRepository _repo;
        private readonly ApplicationDbContext _db;

        public NotasController(INotaRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>> GetAll(CancellationToken ct)
            => Ok(await _repo.ListAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Nota>> GetById(Guid id, CancellationToken ct)
        {
            var item = await _repo.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpGet("por-matricula/{matriculaId:guid}")]
        public async Task<ActionResult<IEnumerable<Nota>>> ListByMatricula(Guid matriculaId, CancellationToken ct)
            => Ok(await _repo.ListByMatriculaAsync(matriculaId, ct));

        [HttpPost]
        public async Task<ActionResult<Nota>> Create([FromBody] Nota input, CancellationToken ct)
        {
            input.Id = Guid.NewGuid();
            await _repo.AddAsync(input, ct);
            await _db.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Nota input, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return NotFound();

            entity.MatriculaId = input.MatriculaId;
            entity.Avaliacao = input.Avaliacao;
            entity.Valor = input.Valor;
            entity.Data = input.Data;

            _repo.Update(entity);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return NotFound();

            _repo.Remove(entity);
            await _db.SaveChangesAsync(ct);
            return NoContent();
        }
    }
}