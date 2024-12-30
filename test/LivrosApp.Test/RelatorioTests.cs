using FluentAssertions;
using LivrosApp.Application;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using Moq;
using System.Linq.Expressions;

namespace LivrosApp.Test
{
    public class RelatorioTests
    {
        [Fact]
        public async Task PdfService_GetRelatorio_ShouldReturnArrayWhenHaveBooks()
        {
            IEnumerable<Livro> livros =
            [
                new()
                {
                    CodL = 1,
                    Titulo = "Teste 1",
                    Editora = "Teste",
                    Edicao = 1,
                    AnoPublicacao = "2024",
                    LivrosAutores = [new() { Livro_CodL = 1, Autor_CodAu = 1, Autor = new() { Nome = "Teste"} }],
                    LivrosAssuntos = [new() { Livro_CodL = 1, Assunto_CodAs = 1, Assunto = new() { Descricao = "Teste"} }],
                    TabelaPrecos = [new() { Valor = 1, CodCv = 1, CanalVenda = new() { CodCv = 1, Nome = "Teste" } }]
                }
            ];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync(livros);

            var pdfService = new PdfService(mockUnitOfWork.Object);

            var result = await pdfService.GetRelatorio();

            result.Should().NotBeNull();
        }
    }
}
