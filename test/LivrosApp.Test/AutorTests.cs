using FluentAssertions;
using LivrosApp.Application;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using Moq;

namespace LivrosApp.Test
{
    public class AutorTests
    {
        [Fact]
        public async Task AutorService_Create_ShouldReturnTrue_WhenValidActorIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.Add(It.IsAny<Autor>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var Autor = new Autor
            {
                Nome = "Teste"
            };

            var result = await AutorService.CreateAutor(Autor);

            result.Should().Be(true);
        }

        [Fact]
        public async Task AutorService_Create_ShouldReturnFalse_WhenInvalidActorIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.Add(It.IsAny<Autor>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var Autor = new Autor
            {
                Nome = ""
            };

            var result = await AutorService.CreateAutor(Autor);

            result.Should().Be(false);
        }

        [Fact]
        public async Task AutorService_Create_ShouldReturnFalse_WhenNoActorIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.Add(It.IsAny<Autor>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.CreateAutor(null);

            result.Should().Be(false);
        }

        [Fact]
        public async Task AutorService_Delete_ShouldReturnTrue_WhenValidIdIsProvided()
        {
            IEnumerable<LivroAutor> livroAutores = new List<LivroAutor>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.Remove(It.IsAny<Autor>()));
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync(new Autor() { Nome = "" });
            mockUnitOfWork.Setup(u => u.LivrosAutores.GetAll(null, "")).ReturnsAsync(livroAutores);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.DeleteAutor(1);

            result.Item1.Should().Be(true);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AutorService_Delete_ShouldReturnFalse_WhenSaveFail()
        {
            IEnumerable<LivroAutor> livroAutores = new List<LivroAutor>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.Remove(It.IsAny<Autor>()));
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync(new Autor() { Nome = "" });
            mockUnitOfWork.Setup(u => u.LivrosAutores.GetAll(null, "")).ReturnsAsync(livroAutores);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.DeleteAutor(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AutorService_Delete_ShouldReturnFalse_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.Remove(It.IsAny<Autor>()));

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.DeleteAutor(0);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AutorService_Delete_ShouldReturnFalse_WhenActorIsRelatedToBook()
        {
            IEnumerable<LivroAutor> livroAutores = [new() { CodLa = 1, Livro_CodL = 1, Autor_CodAu = 1 }];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.LivrosAutores.GetAll(la => la.Autor_CodAu == 1, "")).ReturnsAsync(livroAutores);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.DeleteAutor(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().Be("Não é possível excluir um autor relacionado à um livro.");
        }

        [Fact]
        public async Task AutorService_Delete_ShouldReturnFalse_WhenNoIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.DeleteAutor(0);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AutorService_Delete_ShouldReturnFalse_WhenNoActorIsFound()
        {
            IEnumerable<LivroAutor> livroAutores = new List<LivroAutor>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync((Autor)null);
            mockUnitOfWork.Setup(u => u.LivrosAutores.GetAll(null, "")).ReturnsAsync(livroAutores);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.DeleteAutor(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AutorService_GetAll_ShouldReturnAllActors()
        {
            IEnumerable<Autor> Autors = new List<Autor>
            {
                new Autor { CodAu = 1, Nome = "Teste 1" },
                new Autor { CodAu = 2, Nome = "Teste 2" }
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetAll(null, string.Empty)).ReturnsAsync(Autors);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.GetAllAutores();

            result.Should().HaveCount(2);
            result.Should().Contain(a => a.CodAu == 1);
            result.Should().Contain(a => a.CodAu == 2);
        }

        [Fact]
        public async Task AutorService_GetById_ShouldReturnActor_WhenValidIdIsProvided()
        {
            var Autor = new Autor { CodAu = 1, Nome = "Teste" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync(Autor);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.GetAutorById(1);

            result.Should().NotBeNull();
            result.CodAu.Should().Be(1);
            result.Nome.Should().Be("Teste");
        }

        [Fact]
        public async Task AutorService_GetById_ShouldReturnNull_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.GetAutorById(0);

            result.Should().BeNull();
        }

        [Fact]
        public async Task AutorService_GetById_ShouldReturnNull_WhenNoActorIsFound()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync((Autor)null);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.GetAutorById(1);

            result.Should().BeNull();
        }

        [Fact]
        public async Task AutorService_Update_ShouldReturnTrue_WhenValidActorIsProvided()
        {
            var Autor = new Autor { CodAu = 1, Nome = "Teste" };
            var AutorAtualizado = new Autor { CodAu = 1, Nome = "Teste 1" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync(Autor);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.UpdateAutor(AutorAtualizado);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task AutorService_Update_ShouldReturnFalse_WhenInvalidActorIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.UpdateAutor(null);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task AutorService_Update_ShouldReturnFalse_WhenActorDoesNotExist()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync((Autor)null);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.UpdateAutor(new Autor { CodAu = 1, Nome = "Teste 1" });

            result.Should().BeFalse();
        }

        [Fact]
        public async Task AutorService_Update_ShouldReturnFalse_WhenSaveFail()
        {
            var Autor = new Autor { CodAu = 1, Nome = "Teste" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Autores.GetById(1)).ReturnsAsync(Autor);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var AutorService = new AutorService(mockUnitOfWork.Object);

            var result = await AutorService.UpdateAutor(Autor);

            result.Should().BeFalse();
        }

    }
}