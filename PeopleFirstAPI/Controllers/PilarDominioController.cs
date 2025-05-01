using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PilarDominioController : ControllerBase
    {
        private readonly IPilarDominioAppService _service;

        public PilarDominioController(IPilarDominioAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PilarDominioDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PilarDominioDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PilarDominioDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PilarDominioDto dto)
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
            var response = new ApiResponse<PagedResult<PilarDominioDto>>(resultado);
            return Ok(resultado);
        }

    }
}
