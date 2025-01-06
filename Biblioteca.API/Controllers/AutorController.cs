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
            try
            {
                var autores = await _autorService.GetAllAsync();
                if (autores == null)
                {
                    return NotFound("Autor não encontrado");
                }

                return Ok(autores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AutorDto>>> Get(int id)
        {
            try
            {
                var autor = await _autorService.GetByIdAsync(id);
                if (autor == null)
                {
                    return NotFound("Autor não encontrado");
                }

                return Ok(autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorDto autorDto)
        {
            try
            {
                if (autorDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                var Autor = await _autorService.AddAsync(autorDto);

                return new CreatedAtRouteResult("", new { id = Autor.CodAu }, Autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AutorDto autorDto)
        {
            try
            {
                if (id != autorDto.CodAu)
                {
                    return BadRequest("Id's incompatíveis");
                }

                if (autorDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                await _autorService.UpdateAsync(autorDto);

                return Ok(autorDto);
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
                var autor = await _autorService.GetByIdAsync(id);
                if (autor == null)
                {
                    return NotFound("Autor não encontrado");
                }

                await _autorService.RemoveAsync(id);

                return Ok(autor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
