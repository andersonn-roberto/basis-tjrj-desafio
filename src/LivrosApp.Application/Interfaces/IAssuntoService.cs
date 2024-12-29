using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface IAssuntoService
    {
        Task<bool> CreateAssunto(Assunto detalhesAssunto);
        Task<IEnumerable<Assunto>> GetAllAssuntos();
        Task<Assunto> GetAssuntoById(int codAs);
        Task<bool> UpdateAssunto(Assunto detalhesAssunto);
        Task<(bool, string)> DeleteAssunto(int codAs);
    }
}
