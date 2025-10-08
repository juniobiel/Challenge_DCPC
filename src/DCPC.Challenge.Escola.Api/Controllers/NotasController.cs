using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/notas")]
    public class NotasController : ControllerBase
    {
        private readonly INotasService _service;

        public NotasController( INotasService service )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>> GetAll()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Nota>> GetById( Guid id )
        {
            var item = await _service.ObterPorIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Nota>> Create( [FromBody] Nota input )
        {
            if (input is null) return BadRequest();

            var created = await _service.RegistrarNota(input);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update( Guid id, [FromBody] Nota input )
        {
            var entity = await _service.ObterPorIdAsync(id);
            if (entity is null) return NotFound();

            entity.MatriculaId = input.MatriculaId;
            entity.Avaliacao = input.Avaliacao;
            entity.Valor = input.Valor;
            entity.Data = input.Data;

            await _service.AtualizarNotaAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete( Guid id )
        {
            var removed = await _service.RemoverNotaAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}