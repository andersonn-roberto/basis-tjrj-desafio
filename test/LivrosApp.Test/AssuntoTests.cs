using FluentAssertions;
using LivrosApp.Application;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using Moq;

namespace LivrosApp.Test
{
    public class AssuntoTests
    {
        [Fact]
        public async Task AssuntoService_Create_ShouldReturnTrue_WhenValidSubjectIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.Add(It.IsAny<Assunto>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var assunto = new Assunto
            {
                Descricao = "Teste"
            };

            var result = await assuntoService.CreateAssunto(assunto);

            result.Should().Be(true);
        }

        [Fact]
        public async Task AssuntoService_Create_ShouldReturnFalse_WhenInvalidSubjectIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.Add(It.IsAny<Assunto>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var assunto = new Assunto
            {
                Descricao = ""
            };

            var result = await assuntoService.CreateAssunto(assunto);

            result.Should().Be(false);
        }

        [Fact]
        public async Task AssuntoService_Create_ShouldReturnFalse_WhenNoSubjectIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.Add(It.IsAny<Assunto>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.CreateAssunto(null);

            result.Should().Be(false);
        }

        [Fact]
        public async Task AssuntoService_Delete_ShouldReturnTrue_WhenValidIdIsProvided()
        {
            IEnumerable<LivroAssunto> livroAssuntos = new List<LivroAssunto>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.Remove(It.IsAny<Assunto>()));
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync(new Assunto() { Descricao = "" });
            mockUnitOfWork.Setup(u => u.LivrosAssuntos.GetAll(null, "")).ReturnsAsync(livroAssuntos);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.DeleteAssunto(1);

            result.Item1.Should().Be(true);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AssuntoService_Delete_ShouldReturnFalse_WhenSaveFail()
        {
            IEnumerable<LivroAssunto> livroAssuntos = new List<LivroAssunto>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.Remove(It.IsAny<Assunto>()));
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync(new Assunto() { Descricao = "" });
            mockUnitOfWork.Setup(u => u.LivrosAssuntos.GetAll(null, "")).ReturnsAsync(livroAssuntos);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.DeleteAssunto(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AssuntoService_Delete_ShouldReturnFalse_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.Remove(It.IsAny<Assunto>()));

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.DeleteAssunto(0);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AssuntoService_Delete_ShouldReturnFalse_WhenSubjectIsRelatedToBook()
        {
            IEnumerable<LivroAssunto> livroAssuntos = [new() { CodLa = 1, Livro_CodL = 1, Assunto_CodAs = 1 }];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.LivrosAssuntos.GetAll(la => la.Assunto_CodAs == 1, "")).ReturnsAsync(livroAssuntos);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.DeleteAssunto(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().Be("Não é possível excluir um assunto relacionado à um livro.");
        }

        [Fact]
        public async Task AssuntoService_Delete_ShouldReturnFalse_WhenNoIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.DeleteAssunto(0);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AssuntoService_Delete_ShouldReturnFalse_WhenNoSubjectIsFound()
        {
            IEnumerable<LivroAssunto> livroAssuntos = new List<LivroAssunto>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync((Assunto)null);
            mockUnitOfWork.Setup(u => u.LivrosAssuntos.GetAll(null, "")).ReturnsAsync(livroAssuntos);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.DeleteAssunto(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task AssuntoService_GetAll_ShouldReturnAllSubjects()
        {
            IEnumerable<Assunto> assuntos = new List<Assunto>
            {
                new Assunto { CodAs = 1, Descricao = "Teste 1" },
                new Assunto { CodAs = 2, Descricao = "Teste 2" }
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetAll(null, string.Empty)).ReturnsAsync(assuntos);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.GetAllAssuntos();

            result.Should().HaveCount(2);
            result.Should().Contain(a => a.CodAs == 1);
            result.Should().Contain(a => a.CodAs == 2);
        }

        [Fact]
        public async Task AssuntoService_GetById_ShouldReturnSubject_WhenValidIdIsProvided()
        {
            var assunto = new Assunto { CodAs = 1, Descricao = "Teste" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync(assunto);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.GetAssuntoById(1);

            result.Should().NotBeNull();
            result.CodAs.Should().Be(1);
            result.Descricao.Should().Be("Teste");
        }

        [Fact]
        public async Task AssuntoService_GetById_ShouldReturnNull_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.GetAssuntoById(0);

            result.Should().BeNull();
        }

        [Fact]
        public async Task AssuntoService_GetById_ShouldReturnNull_WhenNoSubjectIsFound()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync((Assunto)null);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.GetAssuntoById(1);

            result.Should().BeNull();
        }

        [Fact]
        public async Task AssuntoService_Update_ShouldReturnTrue_WhenValidSubjectIsProvided()
        {
            var assunto = new Assunto { CodAs = 1, Descricao = "Teste" };
            var assuntoAtualizado = new Assunto { CodAs = 1, Descricao = "Teste 1" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync(assunto);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.UpdateAssunto(assuntoAtualizado);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task AssuntoService_Update_ShouldReturnFalse_WhenInvalidSubjectIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.UpdateAssunto(null);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task AssuntoService_Update_ShouldReturnFalse_WhenSubjectDoesNotExist()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync((Assunto)null);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.UpdateAssunto(new Assunto { CodAs = 1, Descricao = "Teste 1" });

            result.Should().BeFalse();
        }

        [Fact]
        public async Task AssuntoService_Update_ShouldReturnFalse_WhenSaveFail()
        {
            var assunto = new Assunto { CodAs = 1, Descricao = "Teste" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.Assuntos.GetById(1)).ReturnsAsync(assunto);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var assuntoService = new AssuntoService(mockUnitOfWork.Object);

            var result = await assuntoService.UpdateAssunto(assunto);

            result.Should().BeFalse();
        }

    }
}