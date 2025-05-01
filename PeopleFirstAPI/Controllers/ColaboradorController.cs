using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorAppService _service;

        public ColaboradorController(IColaboradorAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorDto>>> GetAll()
        {
            var colaboradores = await _service.GetAllAsync();
            return Ok(colaboradores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorDto>> GetById(int id)
        {
            var colaborador = await _service.GetByIdAsync(id);
            if (colaborador == null) return NotFound();
            return Ok(colaborador);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] ColaboradorDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ColaboradorDto dto)
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
            var response = new ApiResponse<PagedResult<ColaboradorDto>>(resultado);
            return Ok(response);
        }



    }
}
