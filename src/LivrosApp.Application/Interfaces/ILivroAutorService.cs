using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface ILivroAutorService
    {
        Task<bool> CreateLivroAutor(LivroAutor detalhesLivroAutor);
        Task<IEnumerable<LivroAutor>> GetAllLivrosAutores();
        Task<LivroAutor> GetLivroAutorById(int codLa);
        Task<bool> UpdateLivroAutor(LivroAutor detalhesLivroAutor);
        Task<bool> DeleteLivroAutor(int codLa);
    }
}
