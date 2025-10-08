using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/cursos")]
    public class CursosController : ControllerBase
    {
        private readonly ICursosService _service;

        public CursosController(ICursosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Curso>> GetById(Guid id)
        {
            var item = await _service.ObterPorIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> Create([FromBody] Curso input)
        {
            if (input is null) return BadRequest();

            var created = await _service.RegistrarCurso(input);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Curso input)
        {
            var entity = await _service.ObterPorIdAsync(id);
            if (entity is null) return NotFound();

            entity.Nome = input.Nome;
            entity.CargaHoraria = input.CargaHoraria;

            await _service.AtualizarCursoAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _service.RemoverCursoAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}