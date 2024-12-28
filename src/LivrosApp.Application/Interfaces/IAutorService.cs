using LivrosApp.Dominio.Models;

namespace LivrosApp.Application.Interfaces
{
    public interface IAutorService
    {
        Task<bool> CreateAutor(Autor detalhesAutor);
        Task<IEnumerable<Autor>> GetAllAutores();
        Task<Autor> GetAutorById(int codAu);
        Task<bool> UpdateAutor(Autor detalhesAutor);
        Task<bool> DeleteAutor(int codAu);
    }
}
