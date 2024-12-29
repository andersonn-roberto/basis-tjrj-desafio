using LivrosApp.Dominio.Interfaces;
using LivrosApp.Infra.Context;

namespace LivrosApp.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrosAppContext _context;
        public IAssuntoRepository Assuntos { get; }
        public IAutorRepository Autores { get; }
        public ICanalVendaRepository CanaisVenda { get; }
        public ILivroAssuntoRepository LivrosAssuntos { get; }
        public ILivroAutorRepository LivrosAutores { get; }
        public ILivroRepository Livros { get; }
        public ITabelaPrecoRepository TabelasPrecos { get; }

        public UnitOfWork(LivrosAppContext context,
                          IAssuntoRepository assuntos,
                          IAutorRepository autores,
                          ICanalVendaRepository canaisVenda,
                          ILivroAssuntoRepository livrosAssuntos,
                          ILivroAutorRepository livrosAutores,
                          ILivroRepository livros,
                          ITabelaPrecoRepository tabelasPrecos)
        {
            _context = context;
            Assuntos = assuntos;
            Autores = autores;
            CanaisVenda = canaisVenda;
            LivrosAssuntos = livrosAssuntos;
            LivrosAutores = livrosAutores;
            Livros = livros;
            TabelasPrecos = tabelasPrecos;
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
