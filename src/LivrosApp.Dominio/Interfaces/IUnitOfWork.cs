namespace LivrosApp.Dominio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ILivroRepository Livros { get; }
        IAutorRepository Autores { get; }
        int Save();
    }
}
