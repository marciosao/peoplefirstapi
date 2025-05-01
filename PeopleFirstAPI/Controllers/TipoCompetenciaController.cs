using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TipoCompetenciaController : ControllerBase
    {
        private readonly ITipoCompetenciaAppService _service;

        public TipoCompetenciaController(ITipoCompetenciaAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCompetenciaDto>>> GetAll()
        {
            var tipos = await _service.GetAllAsync();
            return Ok(tipos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCompetenciaDto>> GetById(int id)
        {
            var tipo = await _service.GetByIdAsync(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] TipoCompetenciaDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] TipoCompetenciaDto dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL e do corpo devem coincidir.");
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
            var response = new ApiResponse<PagedResult<TipoCompetenciaDto>>(resultado);
            return Ok(resultado);
        }

    }
}
