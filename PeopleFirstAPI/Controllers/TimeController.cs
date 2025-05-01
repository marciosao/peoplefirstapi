using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private readonly ITimeAppService _service;

        public TimeController(ITimeAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeDto>>> GetAll()
        {
            var times = await _service.GetAllAsync();
            return Ok(times);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeDto>> GetById(int id)
        {
            var time = await _service.GetByIdAsync(id);
            if (time == null) return NotFound();
            return Ok(time);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TimeDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TimeDto dto)
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

        [HttpGet("paginado")]
        public async Task<IActionResult> ListarPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _service.ListarPaginadoAsync(page, pageSize);
            var response = new ApiResponse<PagedResult<TimeDto>>(resultado);
            return Ok(resultado);
        }

    }
}
