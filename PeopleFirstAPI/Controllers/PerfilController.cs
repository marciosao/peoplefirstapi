using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeopleFirst.Application.DTOs;
using PeopleFirst.Application.Interfaces;

namespace PeopleFirstAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilAppService _perfilApp;

        public PerfilController(IPerfilAppService perfilApp)
        {
            _perfilApp = perfilApp;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PerfilDto>>> GetAll()
        {
            var perfis = await _perfilApp.GetAllAsync();
            return Ok(perfis);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PerfilDto>> GetById(int id)
        {
            var perfil = await _perfilApp.GetByIdAsync(id);
            if (perfil == null) return NotFound();
            return Ok(perfil);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PerfilDto dto)
        {
            await _perfilApp.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] PerfilDto dto)
        {
            if (id != dto.Id) return BadRequest("ID da URL não corresponde ao do objeto");
            await _perfilApp.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _perfilApp.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("paginado")]
        public async Task<IActionResult> ListarPaginado([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var resultado = await _perfilApp.ListarPaginadoAsync(page, pageSize);
            var response = new ApiResponse<PagedResult<PerfilDto>>(resultado);
            return Ok(resultado);
        }

    }
}
