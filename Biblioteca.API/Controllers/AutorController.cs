using Biblioteca.Application.DTOs;
using Biblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDto>>> Get()
        {
            var autores = await _autorService.GetAllAsync();
            if (autores == null)
            {
                return NotFound("Autor não encontrado");
            }

            return Ok(autores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AutorDto>>> Get(int id)
        {
            var Autors = await _autorService.GetByIdAsync(id);
            if (Autors == null)
            {
                return NotFound("Autor não encontrado");
            }

            return Ok(Autors);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorDto AutorDto)
        {
            if (AutorDto == null)
            {
                return BadRequest("Dado inválido");
            }

            var Autor = await _autorService.AddAsync(AutorDto);

            return new CreatedAtRouteResult("", new { id = Autor.CodAu }, Autor);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AutorDto AutorDto)
        {
            if (id != AutorDto.CodAu)
            {
                return BadRequest("Id's incompatíveis");
            }

            if (AutorDto == null)
            {
                return BadRequest("Dado inválido");
            }

            await _autorService.UpdateAsync(AutorDto);

            return Ok(AutorDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _autorService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("Autor não encontrado");
            }

            await _autorService.RemoveAsync(id);

            return Ok(category);
        }
    }
}
