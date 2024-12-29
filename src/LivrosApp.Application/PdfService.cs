using LivrosApp.Application.Interfaces;
using LivrosApp.Dominio.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace LivrosApp.Application
{
    public class PdfService : IPdfService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PdfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IDocument> GetRelatorio()
        {
            var livros = await _unitOfWork.Livros.GetAll(includeProperties: "LivrosAutores,LivrosAutores.Autor,LivrosAssuntos,LivrosAssuntos.Assunto");

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Content().Element(element =>
                    {
                        element.Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Título");
                                header.Cell().Element(CellStyle).Text("Editora");
                                header.Cell().Element(CellStyle).Text("Edição");
                                header.Cell().Element(CellStyle).Text("Ano Publicação");
                                header.Cell().Element(CellStyle).Text("Autor(es)");
                                header.Cell().Element(CellStyle).Text("Assunto(s)");

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                                }
                            });

                            foreach (var livro in livros)
                            {
                                table.Cell().Element(CellStyle).Text(livro.Titulo);
                                table.Cell().Element(CellStyle).Text(livro.Editora);
                                table.Cell().Element(CellStyle).AlignCenter().Text(livro.Edicao.ToString());
                                table.Cell().Element(CellStyle).AlignCenter().Text(livro.AnoPublicacao);
                                table.Cell().Element(CellStyle).Text(string.Join(",", livro.LivrosAutores.Select(la => la.Autor?.Nome).ToList()));
                                table.Cell().Element(CellStyle).Text(string.Join(",", livro.LivrosAssuntos.Select(la => la.Assunto?.Descricao).ToList()));

                                static IContainer CellStyle(IContainer container)
                                {
                                    return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                                }
                            }
                        });
                    });
                });
            });
        }
    }
}
