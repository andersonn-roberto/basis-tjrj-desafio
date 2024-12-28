using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class AssuntoEntityTypeConfiguration : IEntityTypeConfiguration<Assunto>
    {
        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.ToTable("Assuntos");
            builder.HasKey(a => a.CodAs);
            builder.Property(a => a.Descricao).HasMaxLength(20).IsRequired();
            builder.HasMany(a => a.LivrosAssuntos).WithOne(la => la.Assunto);
        }
    }
}
