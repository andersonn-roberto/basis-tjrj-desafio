using FluentAssertions;
using LivrosApp.Application;
using LivrosApp.Application.Inputs;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using Moq;
using System.Linq.Expressions;

namespace LivrosApp.Test
{
    public class LivroTests
    {
        [Fact]
        public async Task LivroService_Create_ShouldReturnTrue_WhenValidBookIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.Add(It.IsAny<Livro>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var livro = new LivroCreateModel
            {
                Titulo = "Teste",
                Editora = "Teste",
                AnoPublicacao = "2021",
                Edicao = 1,
                LivrosAutores = [1],
                LivrosAssuntos = [1],
                TabelaPrecos = [new() { Valor = 1, CodCv = 1 }]
            };

            var result = await livroService.CreateLivro(livro);

            result.Should().Be(true);
        }

        [Fact]
        public async Task LivroService_Create_ShouldReturnFalse_WhenInvalidBookIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.Add(It.IsAny<Livro>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var livro = new LivroCreateModel
            {
                Titulo = "",
                Editora = "",
                AnoPublicacao = "",
                Edicao = 1,
                LivrosAutores = [],
                LivrosAssuntos = [],
                TabelaPrecos = []
            };

            var result = await livroService.CreateLivro(livro);

            result.Should().Be(false);
        }

        [Fact]
        public async Task LivroService_Create_ShouldReturnFalse_WhenNoBooksIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.Add(It.IsAny<Livro>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.CreateLivro(null);

            result.Should().Be(false);
        }

        [Fact]
        public async Task LivroService_Delete_ShouldReturnTrue_WhenValidIdIsProvided()
        {
            var livro = new Livro
            {
                CodL = 1,
                Titulo = "Teste",
                Editora = "Teste",
                AnoPublicacao = "2021",
                Edicao = 1,
                LivrosAutores = [],
                LivrosAssuntos = [],
                TabelaPrecos = []
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.Remove(It.IsAny<Livro>()));
            mockUnitOfWork.Setup(u => u.Livros.GetById(1)).ReturnsAsync(livro);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.DeleteLivro(1);

            result.Should().Be(true);
        }

        [Fact]
        public async Task LivroService_Delete_ShouldReturnFalse_WhenSaveFail()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.Remove(It.IsAny<Livro>()));
            mockUnitOfWork.Setup(u => u.Livros.GetById(1)).ReturnsAsync(new Livro() { Titulo = "", Editora = "", AnoPublicacao = "" });
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.DeleteLivro(1);

            result.Should().Be(false);
        }

        [Fact]
        public async Task LivroService_Delete_ShouldReturnFalse_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.Remove(It.IsAny<Livro>()));

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.DeleteLivro(0);

            result.Should().Be(false);
        }

        [Fact]
        public async Task LivroService_Delete_ShouldReturnFalse_WhenNoIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.DeleteLivro(0);

            result.Should().Be(false);
        }

        [Fact]
        public async Task LivroService_Delete_ShouldReturnFalse_WhenNoBookIsFound()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.GetById(1)).ReturnsAsync((Livro)null);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.DeleteLivro(1);

            result.Should().Be(false);
        }

        [Fact]
        public async Task LivroService_GetAll_ShouldReturnAllBooks()
        {
            IEnumerable<Livro> livros =
            [
                new() { CodL = 1, Titulo = "Teste 1", Editora = "Teste", AnoPublicacao = "2024" },
                new() { CodL = 2, Titulo = "Teste 2", Editora = "Teste", AnoPublicacao = "2024"}
            ];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync(livros);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.GetAllLivros();

            result.Should().HaveCount(2);
            result.Should().Contain(a => a.CodL == 1);
            result.Should().Contain(a => a.CodL == 2);
        }

        [Fact]
        public async Task LivroService_GetById_ShouldReturnBook_WhenValidIdIsProvided()
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
                    TabelaPrecos = [new() { Valor = 1, CodCv = 1, CanalVenda = new() {CodCv = 1, Nome = "Teste" } }]
                }
            ];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync(livros);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.GetLivroById(1);

            result.Should().NotBeNull();
            result.CodL.Should().Be(1);
            result.Titulo.Should().Be("Teste 1");
            result.Editora.Should().Be("Teste");
            result.Edicao.Should().Be(1);
            result.AnoPublicacao.Should().Be("2024");
            result.LivrosAutores.Should().HaveCount(1);
            result.LivrosAutores[0].Autor.Nome.Should().Be("Teste");
            result.LivrosAssuntos.Should().HaveCount(1);
            result.LivrosAssuntos[0].Assunto.Descricao.Should().Be("Teste");
            result.TabelaPrecos.Should().HaveCount(1);
            result.TabelaPrecos[0].Valor.Should().Be(1);
            result.TabelaPrecos[0].CanalVenda.Nome.Should().Be("Teste");
        }

        [Fact]
        public async Task LivroService_GetById_ShouldReturnNull_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.GetLivroById(0);

            result.Should().BeNull();
        }

        [Fact]
        public async Task LivroService_GetById_ShouldReturnNull_WhenNoBookIsFound()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync([]);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.GetLivroById(2);

            result.Should().BeNull();
        }

        [Fact]
        public async Task LivroService_Update_ShouldReturnTrue_WhenValidBookIsProvided()
        {
            Assunto assuntoOriginal = new() { CodAs = 1, Descricao = "Teste" };
            Autor autorOriginal = new() { CodAu = 1, Nome = "Teste" };
            CanalVenda canalVendaOriginal = new() { CodCv = 1, Nome = "Teste" };

            Assunto assuntoNovo = new() { CodAs = 2, Descricao = "Teste 2" };
            Autor autorNovo = new() { CodAu = 2, Nome = "Teste 2" };
            CanalVenda canalVendaNovo = new() { CodCv = 2, Nome = "Teste 2" };

            IEnumerable<Assunto> assuntos = [assuntoOriginal, assuntoNovo];
            IEnumerable<Autor> autores = [autorOriginal, autorNovo];
            IEnumerable<CanalVenda> canaisVenda = [canalVendaOriginal, canalVendaNovo];

            LivroUpdateModel livroAtualizado = new()
            {
                CodL = 1,
                Titulo = "Teste 2",
                Editora = "Teste 2",
                Edicao = 2,
                AnoPublicacao = "2024",
                LivrosAssuntos = [2],
                LivrosAutores = [2],
                TabelaPrecos = [new() { CodCv = 2, Valor = 2 }]
            };

            IEnumerable<Livro> livros =
            [
                new()
                {
                    CodL = 1,
                    Titulo = "Teste 1",
                    Editora = "Teste 1",
                    Edicao = 1,
                    AnoPublicacao = "2024",
                    LivrosAutores = [new() { Livro_CodL = 1, Autor_CodAu = 1, Autor = autorOriginal }],
                    LivrosAssuntos = [new() { Livro_CodL = 1, Assunto_CodAs = 1, Assunto = assuntoOriginal }],
                    TabelaPrecos = [new() { Valor = 1, CodCv = 1 }]
                }
            ];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetAll(It.IsAny<Expression<Func<Assunto, bool>>>(), It.IsAny<string>())).ReturnsAsync(assuntos);
            mockUnitOfWork.Setup(u => u.Autores.GetAll(It.IsAny<Expression<Func<Autor, bool>>>(), It.IsAny<string>())).ReturnsAsync(autores);
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetAll(It.IsAny<Expression<Func<CanalVenda, bool>>>(), It.IsAny<string>())).ReturnsAsync(canaisVenda);
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync(livros);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.UpdateLivro(livroAtualizado);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task LivroService_Update_ShouldReturnFalse_WhenInvalidBookIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.UpdateLivro(null);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task LivroService_Update_ShouldReturnFalse_WhenBookDoesNotExist()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync([]);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.UpdateLivro(new LivroUpdateModel { CodL = 1, Titulo = "Teste 1", Editora = "Teste 1", AnoPublicacao = "2024" });

            result.Should().BeFalse();
        }

        [Fact]
        public async Task LivroService_Update_ShouldReturnFalse_WhenSaveFail()
        {
            Assunto assuntoOriginal = new() { CodAs = 1, Descricao = "Teste" };
            Autor autorOriginal = new() { CodAu = 1, Nome = "Teste" };
            CanalVenda canalVendaOriginal = new() { CodCv = 1, Nome = "Teste" };

            Assunto assuntoNovo = new() { CodAs = 2, Descricao = "Teste 2" };
            Autor autorNovo = new() { CodAu = 2, Nome = "Teste 2" };
            CanalVenda canalVendaNovo = new() { CodCv = 2, Nome = "Teste 2" };

            IEnumerable<Assunto> assuntos = [assuntoOriginal, assuntoNovo];
            IEnumerable<Autor> autores = [autorOriginal, autorNovo];
            IEnumerable<CanalVenda> canaisVenda = [canalVendaOriginal, canalVendaNovo];

            LivroUpdateModel livroAtualizado = new()
            {
                CodL = 1,
                Titulo = "Teste 2",
                Editora = "Teste 2",
                Edicao = 2,
                AnoPublicacao = "2024",
                LivrosAssuntos = [2],
                LivrosAutores = [2],
                TabelaPrecos = [new() { CodCv = 2, Valor = 2 }]
            };

            IEnumerable<Livro> livros =
            [
                new()
                {
                    CodL = 1,
                    Titulo = "Teste 1",
                    Editora = "Teste 1",
                    Edicao = 1,
                    AnoPublicacao = "2024",
                    LivrosAutores = [new() { Livro_CodL = 1, Autor_CodAu = 1, Autor = autorOriginal }],
                    LivrosAssuntos = [new() { Livro_CodL = 1, Assunto_CodAs = 1, Assunto = assuntoOriginal }],
                    TabelaPrecos = [new() { Valor = 1, CodCv = 1 }]
                }
            ];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetAll(It.IsAny<Expression<Func<Assunto, bool>>>(), It.IsAny<string>())).ReturnsAsync(assuntos);
            mockUnitOfWork.Setup(u => u.Autores.GetAll(It.IsAny<Expression<Func<Autor, bool>>>(), It.IsAny<string>())).ReturnsAsync(autores);
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetAll(It.IsAny<Expression<Func<CanalVenda, bool>>>(), It.IsAny<string>())).ReturnsAsync(canaisVenda);
            mockUnitOfWork.Setup(u => u.Livros.GetAll(It.IsAny<Expression<Func<Livro, bool>>>(), It.IsAny<string>())).ReturnsAsync(livros);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var livroService = new LivroService(mockUnitOfWork.Object);

            var result = await livroService.UpdateLivro(livroAtualizado);

            result.Should().BeFalse();
        }

    }
}