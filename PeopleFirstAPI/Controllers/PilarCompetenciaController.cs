using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PilarCompetenciaController : ControllerBase
    {
        private readonly IPilarCompetenciaAppService _service;

        public PilarCompetenciaController(IPilarCompetenciaAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PilarCompetenciaDto>>> GetAll()
        {
            var pilares = await _service.GetAllAsync();
            return Ok(pilares);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PilarCompetenciaDto>> GetById(int id)
        {
            var pilar = await _service.GetByIdAsync(id);
            if (pilar == null) return NotFound();
            return Ok(pilar);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PilarCompetenciaDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PilarCompetenciaDto dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL e do objeto devem coincidir.");
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
