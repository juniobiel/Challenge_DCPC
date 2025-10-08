using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/professores")]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessoresService _service;

        public ProfessoresController(IProfessoresService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetAll()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Professor>> GetById(Guid id)
        {
            var item = await _service.ObterPorIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> Create([FromBody] Professor input)
        {
            if (input is null) return BadRequest();

            var created = await _service.RegistrarProfessor(input);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Professor input)
        {
            var entity = await _service.ObterPorIdAsync(id);
            if (entity is null) return NotFound();

            entity.Nome = input.Nome;
            entity.Email = input.Email;

            await _service.AtualizarProfessorAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _service.RemoverProfessorAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}