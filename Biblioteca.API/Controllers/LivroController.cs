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
            var Livros = await _livroService.GetAll();
            if (Livros == null)
            {
                return NotFound("Livro não encontrado");
            }

            return Ok(Livros);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<LivroDto>>> Get(int id)
        {
            var Livros = await _livroService.GetById(id);
            if (Livros == null)
            {
                return NotFound("Livro não encontrado");
            }

            return Ok(Livros);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LivroDto LivroDto)
        {
            if (LivroDto == null)
            {
                return BadRequest("Dado inválido");
            }

            var Livro = await _livroService.Add(LivroDto);

            return new CreatedAtRouteResult("", new { id = Livro.CodL }, Livro);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] LivroDto LivroDto)
        {
            if (id != LivroDto.CodL)
            {
                return BadRequest("Id's incompatíveis");
            }

            if (LivroDto == null)
            {
                return BadRequest("Dado inválido");
            }

            await _livroService.Update(LivroDto);

            return Ok(LivroDto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _livroService.GetById(id);
            if (category == null)
            {
                return NotFound("Livro não encontrado");
            }

            await _livroService.Remove(id);

            return Ok(category);
        }
    }
}
