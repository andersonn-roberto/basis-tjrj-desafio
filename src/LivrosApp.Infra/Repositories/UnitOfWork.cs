using LivrosApp.Dominio.Interfaces;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrosAppContext _context;
        public ILivroRepository Livros { get; }
        public IAutorRepository Autores { get; }

        public UnitOfWork(LivrosAppContext context, ILivroRepository repositoryLivro, IAutorRepository autores)
        {
            _context = context;
            Livros = repositoryLivro;
            Autores = autores;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
