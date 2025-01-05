using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.AplicacaoMvc.Controllers
{
    public class AutorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
