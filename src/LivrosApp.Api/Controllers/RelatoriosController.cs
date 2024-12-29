using LivrosApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace LivrosApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        public RelatoriosController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }
        [HttpGet]
        public async Task<IResult> GetRelatorio()
        {
            var relatorio = await _pdfService.GetRelatorio();
            if (relatorio == null)
            {
                return Results.NotFound();
            }
            return Results.File(relatorio.GeneratePdf(), "application/pdf", "livros-app.pdf");
        }
    }
}
