using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class TabelaPrecoEntityTypeConfiguration : IEntityTypeConfiguration<TabelaPreco>
    {
        public void Configure(EntityTypeBuilder<TabelaPreco> builder)
        {
            builder.ToTable("TabelaPrecos");
            builder.HasKey(tp => tp.CodTp);
            builder.Property(tp => tp.Valor).IsRequired();
            builder.HasOne(tp => tp.CanalVenda).WithMany(cv => cv.TabelaPrecos).HasForeignKey(tp => tp.CodCv);
            builder.HasOne(tp => tp.Livro).WithMany(l => l.TabelaPrecos).HasForeignKey(tp => tp.CodL);
        }
    }
}
