using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface ICanalVendaService
    {
        Task<bool> CreateCanalVenda(CanalVenda detalhesCanalVenda);
        Task<IEnumerable<CanalVenda>> GetAllCanaisVenda();
        Task<CanalVenda> GetCanalVendaById(int codCv);
        Task<bool> UpdateCanalVenda(CanalVenda detalhesCanalVenda);
        Task<(bool, string)> DeleteCanalVenda(int codCv);
    }
}
