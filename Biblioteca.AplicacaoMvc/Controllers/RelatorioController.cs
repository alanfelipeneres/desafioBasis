using Biblioteca.AplicacaoMvc.Services;
using FastReport;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

public class RelatorioController : Controller
{
    private readonly RelatorioService _relatorioService;

    public RelatorioController(RelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }

    public async Task<IActionResult> Index()
    {
        // Caminho do relatório
        string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Relatorio.frx");

        var report = new Report();
        report.Load(reportPath);
        var response = await _relatorioService.ObterViewAsync();

        // Configura o JSON Data Source
        report.RegisterData(response, "LivrosPorAutor");
        report.Prepare();

        // Exporta o relatório para HTML
        using (var stream = new MemoryStream())
        {
            var htmlExport = new FastReport.Export.Html.HTMLExport();
            report.Export(htmlExport, stream);

            // Se o relatório foi exportado corretamente, vamos recuperar o HTML
            stream.Seek(0, SeekOrigin.Begin);

            // Ler o conteúdo exportado para HTML
            var htmlContent = new StreamReader(stream).ReadToEnd();

            // Verifique se o conteúdo não está vazio
            if (string.IsNullOrEmpty(htmlContent))
            {
                TempData["ErrorMessage"] = "Falha ao exportar o relatório para HTML.";
            }
            else
            {
                ViewData["ReportHtml"] = htmlContent;
            }
        }

        return View();
    }
}
