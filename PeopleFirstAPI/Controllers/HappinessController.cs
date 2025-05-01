using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HappinessController : ControllerBase
    {
        private readonly IHappinessAppService _service;

        public HappinessController(IHappinessAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HappinessDto>>> GetAll()
        {
            var avaliacoes = await _service.GetAllAsync();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HappinessDto>> GetById(int id)
        {
            var avaliacao = await _service.GetByIdAsync(id);
            if (avaliacao == null) return NotFound();
            return Ok(avaliacao);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HappinessDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] HappinessDto dto)
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
            var response = new ApiResponse<PagedResult<HappinessDto>>(resultado);
            return Ok(resultado);
        }

    }
}
