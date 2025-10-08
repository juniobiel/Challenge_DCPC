using DCPC.Challenge.Escola.Api.Models;
using DCPC.Challenge.Escola.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DCPC.Challenge.Escola.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/alunos")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosService _service;

        public AlunosController(IAlunosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAll()
            => Ok(await _service.ListarAsync());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Aluno>> GetById(Guid id)
        {
            var item = await _service.ObterComMatriculasAsync(id)
                       ?? await _service.ObterPorIdAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Create([FromBody] Aluno input)
        {
            if (input is null) return BadRequest();

            var aluno = await _service.RegistrarAluno(input);
            return CreatedAtAction(nameof(GetById), new { id = aluno.Id }, aluno);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Aluno input)
        {
            var entity = await _service.ObterPorIdAsync(id);
            if (entity is null) return NotFound();

            entity.Nome = input.Nome;
            entity.Email = input.Email;
            entity.DataNascimento = input.DataNascimento;
            entity.Ativo = input.Ativo;

            await _service.AtualizarAlunoAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removed = await _service.RemoverAlunoAsync(id);
            return removed ? NoContent() : NotFound();
        }
    }
}
