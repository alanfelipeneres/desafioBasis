using Biblioteca.AplicacaoMvc.Models;
using Biblioteca.AplicacaoMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.AplicacaoMvc.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroService _livroService;

        public LivroController(LivroService livroService)
        {
            _livroService = livroService;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _livroService.ObterLivrosAsync();
            return View(livros);
        }

        [HttpPost]
        public async Task<IActionResult> Criar(LivroVM livro)
        {
            var novoLivro = await _livroService.CriarLivroAsync(livro);
            return RedirectToAction("Index");
        }
    }
}
