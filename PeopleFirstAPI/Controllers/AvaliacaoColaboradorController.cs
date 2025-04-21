using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoColaboradorController : ControllerBase
    {
        private readonly IAvaliacaoColaboradorAppService _service;

        public AvaliacaoColaboradorController(IAvaliacaoColaboradorAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvaliacaoColaboradorDto>>> GetAll()
        {
            var avaliacoes = await _service.GetAllAsync();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AvaliacaoColaboradorDto>> GetById(int id)
        {
            var avaliacao = await _service.GetByIdAsync(id);
            if (avaliacao == null) return NotFound();
            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AvaliacaoColaboradorDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AvaliacaoColaboradorDto dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL e do corpo devem ser iguais.");
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
