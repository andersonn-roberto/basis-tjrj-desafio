using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class LivroAutorEntityTypeConfiguration : IEntityTypeConfiguration<LivroAutor>
    {
        public void Configure(EntityTypeBuilder<LivroAutor> builder)
        {
            builder.ToTable("LivrosAutores");
            builder.HasKey(la => la.CodLa);
            builder.HasOne(la => la.Livro).WithMany(l => l.LivrosAutores).HasForeignKey(la => la.Livro_CodL);
            builder.HasOne(la => la.Autor).WithMany(a => a.LivrosAutores).HasForeignKey(la => la.Autor_CodAu);
        }
    }
}
