using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class LivroAssuntoEntityTypeConfiguration : IEntityTypeConfiguration<LivroAssunto>
    {
        public void Configure(EntityTypeBuilder<LivroAssunto> builder)
        {
            builder.ToTable("LivrosAssuntos");
            builder.HasKey(la => la.CodLa);
            builder.HasOne(la => la.Livro).WithMany(l => l.LivrosAssuntos).HasForeignKey(la => la.Livro_CodL);
            builder.HasOne(la => la.Assunto).WithMany(a => a.LivrosAssuntos).HasForeignKey(la => la.Assunto_CodAs);
        }
    }
}
