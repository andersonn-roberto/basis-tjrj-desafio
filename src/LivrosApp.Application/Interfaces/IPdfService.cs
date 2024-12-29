using QuestPDF.Infrastructure;

namespace LivrosApp.Application.Interfaces
{
    public interface IPdfService
    {
        Task<IDocument> GetRelatorio();
    }
}
