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
            try
            {
                var assuntos = await _assuntoService.GetAllAsync();
                if (assuntos == null)
                {
                    return NotFound("Assunto não encontrado");
                }

                return Ok(assuntos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AssuntoDto>>> Get(int id)
        {
            try
            {
                var assuntos = await _assuntoService.GetByIdAsync(id);
                if (assuntos == null)
                {
                    return NotFound("Assunto não encontrado");
                }

                return Ok(assuntos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssuntoDto assuntoDto)
        {
            try
            {
                if (assuntoDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                var assunto = await _assuntoService.AddAsync(assuntoDto);

                return new CreatedAtRouteResult("", new { id = assunto.CodAs }, assunto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AssuntoDto assuntoDto)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var assunto = await _assuntoService.GetByIdAsync(id);
                if (assunto == null)
                {
                    return NotFound("Assunto não encontrado");
                }

                await _assuntoService.RemoveAsync(id);

                return Ok(assunto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
