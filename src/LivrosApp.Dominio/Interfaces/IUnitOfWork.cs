namespace LivrosApp.Dominio.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAssuntoRepository Assuntos { get; }
        IAutorRepository Autores { get; }
        ICanalVendaRepository CanaisVenda { get; }
        ILivroAssuntoRepository LivrosAssuntos { get; }
        ILivroAutorRepository LivrosAutores { get; }
        ILivroRepository Livros { get; }
        ITabelaPrecoRepository TabelasPrecos { get; }
        int Save();
    }
}
