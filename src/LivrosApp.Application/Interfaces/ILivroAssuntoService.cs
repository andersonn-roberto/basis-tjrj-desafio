using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface ILivroAssuntoService
    {
        Task<bool> CreateLivroAssunto(LivroAssunto detalhesLivroAssunto);
        Task<IEnumerable<LivroAssunto>> GetAllLivrosAssuntos();
        Task<LivroAssunto> GetLivroAssuntoById(int codLa);
        Task<bool> UpdateLivroAssunto(LivroAssunto detalhesLivroAssunto);
        Task<bool> DeleteLivroAssunto(int codLa);
    }
}
