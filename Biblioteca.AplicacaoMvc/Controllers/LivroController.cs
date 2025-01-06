using Biblioteca.AplicacaoMvc.Models;
using Biblioteca.AplicacaoMvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.AplicacaoMvc.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroService _livroService;
        private readonly AutorService _autorService;
        private readonly AssuntoService _assuntoService;

        public LivroController(LivroService livroService, AutorService autorService, AssuntoService assuntoService)
        {
            _livroService = livroService;
            _autorService = autorService;
            _assuntoService = assuntoService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var livros = await _livroService.ObterLivrosAsync();
                return View(livros);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Autores = await _autorService.ObterAutoresAsync();
                ViewBag.Assuntos = await _assuntoService.ObterAssuntosAsync();
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(LivroVM livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _livroService.CriarLivroAsync(livro);
                    return RedirectToAction("Index");
                }

                ViewBag.Autores = await _autorService.ObterAutoresAsync();
                ViewBag.Assuntos = await _assuntoService.ObterAssuntosAsync();
                return View(livro);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(livro);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                // Obtenha o livro
                var livro = await _livroService.ObterLivroPorIdAsync(id.Value);
                if (livro == null)
                {
                    return NotFound();
                }

                // Obtenha os autores e assuntos
                var autores = await _autorService.ObterAutoresAsync();
                var assuntos = await _assuntoService.ObterAssuntosAsync();

                // Armazene nas ViewBags para uso na View
                ViewBag.Autores = autores.ToDictionary(a => a.CodAu, a => a.Nome);
                ViewBag.Assuntos = assuntos.ToDictionary(a => a.CodAs, a => a.Descricao);

                return View(livro);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var livro = await _livroService.ObterLivroPorIdAsync(id.Value);
                if (livro == null)
                {
                    return NotFound();
                }

                var autores = await _autorService.ObterAutoresAsync();
                var assuntos = await _assuntoService.ObterAssuntosAsync();

                ViewBag.Autores = autores.Select(a => new SelectListItem
                {
                    Value = a.CodAu.ToString(),
                    Text = a.Nome
                }).ToList();

                ViewBag.Assuntos = assuntos.Select(a => new SelectListItem
                {
                    Value = a.CodAs.ToString(),
                    Text = a.Descricao
                }).ToList();

                return View(livro);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LivroVM livro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _livroService.EditarLivroAsync(livro);
                    return RedirectToAction("Index");
                }

                // Recarregar ViewBag caso o ModelState seja inválido
                var autores = await _autorService.ObterAutoresAsync();
                var assuntos = await _assuntoService.ObterAssuntosAsync();

                ViewBag.Autores = autores.Select(a => new SelectListItem
                {
                    Value = a.CodAu.ToString(),
                    Text = a.Nome
                }).ToList();

                ViewBag.Assuntos = assuntos.Select(a => new SelectListItem
                {
                    Value = a.CodAs.ToString(),
                    Text = a.Descricao
                }).ToList();

                return View(livro);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(livro);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var Livro = await _livroService.ObterLivroPorIdAsync(id.Value);
                return View(Livro);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(LivroVM livro)
        {
            try
            {
                await _livroService.ExcluirLivroAsync(livro.CodL);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
