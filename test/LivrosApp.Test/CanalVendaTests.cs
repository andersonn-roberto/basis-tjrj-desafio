using FluentAssertions;
using LivrosApp.Application;
using LivrosApp.Dominio.Interfaces;
using LivrosApp.Dominio.Models;
using Moq;

namespace LivrosApp.Test
{
    public class CanalVendaTests
    {
        [Fact]
        public async Task CanalVendaService_Create_ShouldReturnTrue_WhenValidSaleChannelIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.Add(It.IsAny<CanalVenda>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var CanalVenda = new CanalVenda
            {
                Nome = "Teste"
            };

            var result = await CanalVendaService.CreateCanalVenda(CanalVenda);

            result.Should().Be(true);
        }

        [Fact]
        public async Task CanalVendaService_Create_ShouldReturnFalse_WhenInvalidSaleChannelIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.Add(It.IsAny<CanalVenda>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var CanalVenda = new CanalVenda
            {
                Nome = ""
            };

            var result = await CanalVendaService.CreateCanalVenda(CanalVenda);

            result.Should().Be(false);
        }

        [Fact]
        public async Task CanalVendaService_Create_ShouldReturnFalse_WhenNoSaleChannelsIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.Add(It.IsAny<CanalVenda>()));
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.CreateCanalVenda(null);

            result.Should().Be(false);
        }

        [Fact]
        public async Task CanalVendaService_Delete_ShouldReturnTrue_WhenValidIdIsProvided()
        {
            IEnumerable<TabelaPreco> tabelaPrecos = new List<TabelaPreco>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.Remove(It.IsAny<CanalVenda>()));
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync(new CanalVenda() { Nome = "" });
            mockUnitOfWork.Setup(u => u.TabelasPrecos.GetAll(null, "")).ReturnsAsync(tabelaPrecos);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.DeleteCanalVenda(1);

            result.Item1.Should().Be(true);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task CanalVendaService_Delete_ShouldReturnFalse_WhenSaveFail()
        {
            IEnumerable<TabelaPreco> tabelPrecos = new List<TabelaPreco>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.Remove(It.IsAny<CanalVenda>()));
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync(new CanalVenda() { Nome = "" });
            mockUnitOfWork.Setup(u => u.TabelasPrecos.GetAll(null, "")).ReturnsAsync(tabelPrecos);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.DeleteCanalVenda(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task CanalVendaService_Delete_ShouldReturnFalse_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.Remove(It.IsAny<CanalVenda>()));

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.DeleteCanalVenda(0);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task CanalVendaService_Delete_ShouldReturnFalse_WhenSaleChannelIsRelatedToBook()
        {
            IEnumerable<TabelaPreco> tabelaPrecos = [new() { CodTp = 1, CodCv = 1, CodL = 1 }];

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.TabelasPrecos.GetAll(la => la.CodCv == 1, "")).ReturnsAsync(tabelaPrecos);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.DeleteCanalVenda(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().Be("Não é possível excluir um canal de venda relacionado à uma tabela de preços.");
        }

        [Fact]
        public async Task CanalVendaService_Delete_ShouldReturnFalse_WhenNoIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.DeleteCanalVenda(0);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task CanalVendaService_Delete_ShouldReturnFalse_WhenNoSaleChannelIsFound()
        {
            IEnumerable<TabelaPreco> tabelaPrecos = new List<TabelaPreco>();

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync((CanalVenda)null);
            mockUnitOfWork.Setup(u => u.TabelasPrecos.GetAll(null, "")).ReturnsAsync(tabelaPrecos);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.DeleteCanalVenda(1);

            result.Item1.Should().Be(false);
            result.Item2.Should().BeEmpty();
        }

        [Fact]
        public async Task CanalVendaService_GetAll_ShouldReturnAllSaleChannels()
        {
            IEnumerable<CanalVenda> canalVendas = new List<CanalVenda>
            {
                new CanalVenda { CodCv = 1, Nome = "Teste 1" },
                new CanalVenda { CodCv = 2, Nome = "Teste 2" }
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetAll(null, string.Empty)).ReturnsAsync(canalVendas);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.GetAllCanaisVenda();

            result.Should().HaveCount(2);
            result.Should().Contain(a => a.CodCv == 1);
            result.Should().Contain(a => a.CodCv == 2);
        }

        [Fact]
        public async Task CanalVendaService_GetById_ShouldReturnSaleChannel_WhenValidIdIsProvided()
        {
            var CanalVenda = new CanalVenda { CodCv = 1, Nome = "Teste" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync(CanalVenda);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.GetCanalVendaById(1);

            result.Should().NotBeNull();
            result.CodCv.Should().Be(1);
            result.Nome.Should().Be("Teste");
        }

        [Fact]
        public async Task CanalVendaService_GetById_ShouldReturnNull_WhenInvalidIdIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.GetCanalVendaById(0);

            result.Should().BeNull();
        }

        [Fact]
        public async Task CanalVendaService_GetById_ShouldReturnNull_WhenNoSaleChannelIsFound()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync((CanalVenda)null);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.GetCanalVendaById(1);

            result.Should().BeNull();
        }

        [Fact]
        public async Task CanalVendaService_Update_ShouldReturnTrue_WhenValidSaleChannelIsProvided()
        {
            var CanalVenda = new CanalVenda { CodCv = 1, Nome = "Teste" };
            var CanalVendaAtualizado = new CanalVenda { CodCv = 1, Nome = "Teste 1" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync(CanalVenda);
            mockUnitOfWork.Setup(u => u.Save()).Returns(1);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.UpdateCanalVenda(CanalVendaAtualizado);

            result.Should().BeTrue();
        }

        [Fact]
        public async Task CanalVendaService_Update_ShouldReturnFalse_WhenInvalidSaleChannelIsProvided()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.UpdateCanalVenda(null);

            result.Should().BeFalse();
        }

        [Fact]
        public async Task CanalVendaService_Update_ShouldReturnFalse_WhenSaleChannelDoesNotExist()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync((CanalVenda)null);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.UpdateCanalVenda(new CanalVenda { CodCv = 1, Nome = "Teste 1" });

            result.Should().BeFalse();
        }

        [Fact]
        public async Task CanalVendaService_Update_ShouldReturnFalse_WhenSaveFail()
        {
            var CanalVenda = new CanalVenda { CodCv = 1, Nome = "Teste" };

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CanaisVenda.GetById(1)).ReturnsAsync(CanalVenda);
            mockUnitOfWork.Setup(u => u.Save()).Returns(0);

            var CanalVendaService = new CanalVendaService(mockUnitOfWork.Object);

            var result = await CanalVendaService.UpdateCanalVenda(CanalVenda);

            result.Should().BeFalse();
        }

    }
}