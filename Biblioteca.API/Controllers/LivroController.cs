using Biblioteca.Application.DTOs;
using Biblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> Get()
        {
            try
            {
                var Livros = await _livroService.GetAllAsync();
                if (Livros == null)
                {
                    return NotFound("Livro não encontrado");
                }

                return Ok(Livros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<LivroDto>>> Get(int id)
        {
            try
            {
                var Livros = await _livroService.GetByIdAsync(id);
                if (Livros == null)
                {
                    return NotFound("Livro não encontrado");
                }

                return Ok(Livros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LivroDto LivroDto)
        {
            try
            {
                if (LivroDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                var Livro = await _livroService.AddAsync(LivroDto);

                return new CreatedAtRouteResult("", new { id = Livro.CodL }, Livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] LivroDto LivroDto)
        {
            try
            {
                if (id != LivroDto.CodL)
                {
                    return BadRequest("Id's incompatíveis");
                }

                if (LivroDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                await _livroService.UpdateAsync(LivroDto);

                return Ok(LivroDto);
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
                var category = await _livroService.GetByIdAsync(id);
                if (category == null)
                {
                    return NotFound("Livro não encontrado");
                }

                await _livroService.RemoveAsync(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
