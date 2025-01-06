using Biblioteca.AplicacaoMvc.Models;
using Biblioteca.AplicacaoMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.AplicacaoMvc.Controllers
{
    public class AssuntoController : Controller
    {
        private readonly AssuntoService _assuntoService;

        public AssuntoController(AssuntoService assuntoService)
        {
            _assuntoService = assuntoService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var assuntos = await _assuntoService.ObterAssuntosAsync();
                return View(assuntos);
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
        public async Task<IActionResult> Create(AssuntoVM assunto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _assuntoService.CriarAssuntoAsync(assunto);
                    return RedirectToAction("Index");
                }

                return View(assunto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(assunto);
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
                var assunto = await _assuntoService.ObterAssuntoPorIdAsync(id.Value);
                return View(assunto);
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
                var assunto = await _assuntoService.ObterAssuntoPorIdAsync(id.Value);
                return View(assunto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AssuntoVM assunto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _assuntoService.EditarAssuntoAsync(assunto);
                    return RedirectToAction("Index");
                }

                return View(assunto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(assunto);
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
                var assunto = await _assuntoService.ObterAssuntoPorIdAsync(id.Value);
                return View(assunto);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AssuntoVM assunto)
        {
            try
            {
                await _assuntoService.ExcluirAssuntoAsync(assunto.CodAs.Value);
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
