using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackAppService _service;

        public FeedbackController(IFeedbackAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetAll()
        {
            var feedbacks = await _service.GetAllAsync();
            return Ok(feedbacks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackDto>> GetById(int id)
        {
            var feedback = await _service.GetByIdAsync(id);
            if (feedback == null) return NotFound();
            return Ok(feedback);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FeedbackDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] FeedbackDto dto)
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
            var response = new ApiResponse<PagedResult<FeedbackDto>>(resultado);
            return Ok(resultado);
        }

    }
}
