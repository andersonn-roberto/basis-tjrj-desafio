using LivrosApp.Application.Inputs;
using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface ILivroService
    {
        Task<bool> CreateLivro(LivroCreateModel detalhesLivro);
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int codL);
        Task<bool> UpdateLivro(LivroUpdateModel detalhesLivro);
        Task<bool> DeleteLivro(int codL);
    }
}
