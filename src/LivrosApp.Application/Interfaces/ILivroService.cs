using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface ILivroService
    {
        Task<bool> CreateLivro(Livro detalhesLivro);
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int codL);
        Task<bool> UpdateLivro(Livro detalhesLivro);
        Task<bool> DeleteLivro(int codL);
    }
}
