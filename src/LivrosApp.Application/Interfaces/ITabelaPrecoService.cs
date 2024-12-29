using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface ITabelaPrecoService
    {
        Task<bool> CreateTabelaPreco(TabelaPreco detalhesTabelaPreco);
        Task<IEnumerable<TabelaPreco>> GetAllTabelasPreco();
        Task<TabelaPreco> GetTabelaPrecoById(int codTp);
        Task<bool> UpdateTabelaPreco(TabelaPreco detalhesTabelaPreco);
        Task<bool> DeleteTabelaPreco(int codTp);
    }
}
