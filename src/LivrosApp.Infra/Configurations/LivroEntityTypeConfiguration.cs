using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class LivroEntityTypeConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(l => l.CodL);
            builder.Property(l => l.Titulo).HasMaxLength(40).IsRequired();
            builder.Property(l => l.Editora).HasMaxLength(40).IsRequired();
            builder.Property(l => l.Edicao).IsRequired();
            builder.Property(l => l.AnoPublicacao).HasMaxLength(4).IsRequired();
            builder.HasMany(l => l.LivrosAutores).WithOne(la => la.Livro);
            builder.HasMany(l => l.LivrosAssuntos).WithOne(la => la.Livro);
        }
    }
}
