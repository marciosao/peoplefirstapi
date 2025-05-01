using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class QuestaoPilarController : ControllerBase
    {
        private readonly IQuestaoPilarAppService _service;

        public QuestaoPilarController(IQuestaoPilarAppService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestaoPilarDto>>> GetAll()
        {
            var lista = await _service.GetAllAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestaoPilarDto>> GetById(int id)
        {
            var questao = await _service.GetByIdAsync(id);
            if (questao == null) return NotFound();
            return Ok(questao);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] QuestaoPilarDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] QuestaoPilarDto dto)
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
            var response = new ApiResponse<PagedResult<QuestaoPilarDto>>(resultado);
            return Ok(resultado);
        }

    }
}
