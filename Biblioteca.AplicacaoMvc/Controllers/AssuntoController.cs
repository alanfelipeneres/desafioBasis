using Biblioteca.AplicacaoMvc.Models;
using Biblioteca.AplicacaoMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.AplicacaoMvc.Controllers
{
    public class AssuntoController : Controller
    {
        private readonly AssuntoService _assuntoService;

        public AssuntoController(AssuntoService assuntoSercice)
        {
            _assuntoService = assuntoSercice;
        }

        public async Task<IActionResult> Index()
        {
            var assuntos = await _assuntoService.ObterAssuntosAsync();
            return View(assuntos);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssuntoVM assunto)
        {
            var novoAssunto = await _assuntoService.CriarAssuntoAsync(assunto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _assuntoService.ObterAssuntoPorIdAsync(id.Value);
            return View(assunto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _assuntoService.ObterAssuntoPorIdAsync(id.Value);
            return View(assunto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AssuntoVM assunto)
        {
            var assuntoAlterado = await _assuntoService.EditarAssuntoAsync(assunto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assunto = await _assuntoService.ObterAssuntoPorIdAsync(id.Value);
            return View(assunto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AssuntoVM assunto)
        {
            await _assuntoService.ExcluirAssuntoAsync(assunto.CodAs.Value);
            return RedirectToAction("Index");
        }
    }
}
