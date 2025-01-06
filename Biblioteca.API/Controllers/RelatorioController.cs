using Biblioteca.Application.DTOs;
using Biblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IViewLivrosPorAutorService _viewService;

        public RelatorioController(IViewLivrosPorAutorService viewService)
        {
            _viewService = viewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewLivrosPorAutorDto>>> Get()
        {
            try
            {
                var view = await _viewService.GetAllAsync();
                if (view == null)
                {
                    return NotFound("Nenhum resultado encontrado");
                }

                return Ok(view);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
