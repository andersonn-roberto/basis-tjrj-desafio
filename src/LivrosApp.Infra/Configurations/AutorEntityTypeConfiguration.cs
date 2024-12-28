using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class AutorEntityTypeConfiguration : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autores");
            builder.HasKey(a => a.CodAu);
            builder.Property(a => a.Nome).HasMaxLength(40).IsRequired();
            builder.HasMany(a => a.LivrosAutores).WithOne(la => la.Autor);
        }
    }
}
