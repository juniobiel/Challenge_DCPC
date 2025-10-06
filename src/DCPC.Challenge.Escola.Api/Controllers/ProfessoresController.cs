using DCPC.Challenge.Escola.Api.Data;
using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Route("api/professores")]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorRepository _repo;
        private readonly ApplicationDbContext _db;

        public ProfessoresController(IProfessorRepository repo, ApplicationDbContext db)
        {
            _repo = repo;
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetAll(CancellationToken ct)
            => Ok(await _repo.ListAsync(ct));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Professor>> GetById(Guid id, CancellationToken ct)
        {
            var item = await _repo.GetByIdAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> Create([FromBody] Professor input, CancellationToken ct)
        {
            input.Id = Guid.NewGuid();
            await _repo.AddAsync(input, ct);
            await _db.SaveChangesAsync(ct);
            return CreatedAtAction(nameof(GetById), new { id = input.Id }, input);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Professor input, CancellationToken ct)
        {
            var entity = await _repo.GetByIdAsync(id, ct);
            if (entity is null) return NotFound();

            entity.Nome = input.Nome;
            entity.Email = input.Email;

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