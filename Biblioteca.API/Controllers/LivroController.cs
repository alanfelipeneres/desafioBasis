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
                var livros = await _livroService.GetAllAsync();
                if (livros == null)
                {
                    return NotFound("Livro não encontrado");
                }

                return Ok(livros);
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
                var livros = await _livroService.GetByIdWithRelationsAsync(id);
                if (livros == null)
                {
                    return NotFound("Livro não encontrado");
                }

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LivroDto livroDto)
        {
            try
            {
                if (livroDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                var Livro = await _livroService.AddAsync(livroDto);

                return new CreatedAtRouteResult("", new { id = Livro.CodL }, Livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] LivroDto livroDto)
        {
            try
            {
                if (id != livroDto.CodL)
                {
                    return BadRequest("Id's incompatíveis");
                }

                if (livroDto == null)
                {
                    return BadRequest("Dado inválido");
                }

                await _livroService.UpdateAsync(livroDto);

                return Ok(livroDto);
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
                var livro = await _livroService.GetByIdAsync(id);
                if (livro == null)
                {
                    return NotFound("Livro não encontrado");
                }

                await _livroService.RemoveAsync(id);

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
