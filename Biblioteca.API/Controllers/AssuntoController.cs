using Biblioteca.Application.DTOs;
using Biblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntoController : ControllerBase
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoController(IAssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> Get()
        {
            var assuntos = await _assuntoService.GetAllAsync();
            if (assuntos == null)
            {
                return NotFound("Assunto não encontrado");
            }

            return Ok(assuntos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> Get(int id)
        {
            var assuntos = await _assuntoService.GetByIdAsync(id);
            if (assuntos == null)
            {
                return NotFound("Assunto não encontrado");
            }

            return Ok(assuntos);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssuntoDto assuntoDto)
        {
            if (assuntoDto == null)
            {
                return BadRequest("Dado inválido");
            }

            var assunto = await _assuntoService.AddAsync(assuntoDto);

            return new CreatedAtRouteResult("", new { id = assunto.CodAs }, assunto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AssuntoDto assuntoDto)
        {
            if (id != assuntoDto.CodAs)
            {
                return BadRequest("Id's incompatíveis");
            }

            if (assuntoDto == null)
            {
                return BadRequest("Dado inválido");
            }

            await _assuntoService.UpdateAsync(assuntoDto);

            return Ok(assuntoDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _assuntoService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound("Assunto não encontrado");
            }

            await _assuntoService.RemoveAsync(id);

            return Ok(category);
        }
    }
}
