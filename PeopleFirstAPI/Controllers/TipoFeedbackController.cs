using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TipoFeedbackController : ControllerBase
    {
        private readonly ITipoFeedbackAppService _service;

        public TipoFeedbackController(ITipoFeedbackAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoFeedbackDto>>> GetAll()
        {
            var tipos = await _service.GetAllAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoFeedbackDto>> GetById(int id)
        {
            var tipo = await _service.GetByIdAsync(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TipoFeedbackDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TipoFeedbackDto dto)
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

        [HttpGet("paginado")]
        public async Task<IActionResult> ListarPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _service.ListarPaginadoAsync(page, pageSize);
            var response = new ApiResponse<PagedResult<TipoFeedbackDto>>(resultado);
            return Ok(resultado);
        }

    }
}
