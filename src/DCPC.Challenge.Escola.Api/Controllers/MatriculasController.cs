using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/matriculas")]
    public class MatriculasController : ControllerBase
    {
        private readonly IMatriculasService _service;

        public MatriculasController(IMatriculasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matricula>>> GetAll()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Matricula>> GetById(Guid id)
        {
            var item = await _service.ObterPorIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Matricula>> Create([FromBody] Matricula input)
        {
            if (input is null) return BadRequest();

            var created = await _service.RegistrarMatricula(input);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Matricula input)
        {
            var entity = await _service.ObterPorIdAsync(id);
            if (entity is null) return NotFound();

            entity.AlunoId = input.AlunoId;
            entity.TurmaId = input.TurmaId;
            entity.DataMatricula = input.DataMatricula;
            entity.Status = input.Status;

            await _service.AtualizarMatriculaAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _service.RemoverMatriculaAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}