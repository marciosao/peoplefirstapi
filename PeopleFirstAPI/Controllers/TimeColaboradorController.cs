using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TimeColaboradorController : ControllerBase
    {
        private readonly ITimeColaboradorAppService _service;

        public TimeColaboradorController(ITimeColaboradorAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeColaboradorDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeColaboradorDto>> GetById(int id)
        {
            var vinculo = await _service.GetByIdAsync(id);
            if (vinculo == null) return NotFound();
            return Ok(vinculo);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TimeColaboradorDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TimeColaboradorDto dto)
        {
            if (id != dto.Id) return BadRequest("ID do corpo e da URL devem ser iguais.");
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
