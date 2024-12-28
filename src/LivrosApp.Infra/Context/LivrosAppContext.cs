using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LivrosApp.Infra.Context
{
    public class LivrosAppContext : DbContext
    {
        public LivrosAppContext(DbContextOptions<LivrosAppContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }
        public DbSet<LivroAssunto> LivroAssuntos { get; set; }
        public DbSet<CanalVenda> CanalVendas { get; set; }
        public DbSet<TabelaPreco> TabelaPrecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
