using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/turmas")]
    public class TurmasController : ControllerBase
    {
        private readonly ITurmasService _service;

        public TurmasController(ITurmasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetAll()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Turma>> GetById(Guid id)
        {
            var item = await _service.ObterPorIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Turma>> Create([FromBody] Turma input)
        {
            if (input is null) return BadRequest();

            var created = await _service.RegistrarTurma(input);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Turma input)
        {
            var entity = await _service.ObterPorIdAsync(id);
            if (entity is null) return NotFound();

            entity.Nome = input.Nome;
            entity.AnoLetivo = input.AnoLetivo;
            entity.Semestre = input.Semestre;
            entity.CursoId = input.CursoId;
            entity.ProfessorId = input.ProfessorId;

            await _service.AtualizarTurmaAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _service.RemoverTurmaAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}