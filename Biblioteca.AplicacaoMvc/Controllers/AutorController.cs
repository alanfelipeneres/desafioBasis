using Biblioteca.AplicacaoMvc.Models;
using Biblioteca.AplicacaoMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.AplicacaoMvc.Controllers
{
    public class AutorController : Controller
    {
        private readonly AutorService _autorService;

        public AutorController(AutorService autorService)
        {
            _autorService = autorService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var autores = await _autorService.ObterAutoresAsync();
                return View(autores);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AutorVM autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _autorService.CriarAutorAsync(autor);
                    return RedirectToAction("Index");
                }

                return View(autor);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(autor);
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
                var autor = await _autorService.ObterAutorPorIdAsync(id.Value);
                return View(autor);
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
                var autor = await _autorService.ObterAutorPorIdAsync(id.Value);
                return View(autor);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AutorVM autor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _autorService.EditarAutorAsync(autor);
                    return RedirectToAction("Index");
                }

                return View(autor);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(autor);
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
                var autor = await _autorService.ObterAutorPorIdAsync(id.Value);
                return View(autor);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AutorVM autor)
        {
            try
            {
                await _autorService.ExcluirAutorAsync(autor.CodAu);
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
