using LivrosApp.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LivrosApp.Infra.Configurations
{
    public class CanalVendaEntityTypeConfiguration : IEntityTypeConfiguration<CanalVenda>
    {
        public void Configure(EntityTypeBuilder<CanalVenda> builder)
        {
            builder.ToTable("CanalVendas");
            builder.HasKey(cv => cv.CodCv);
            builder.Property(cv => cv.Nome).HasMaxLength(20).IsRequired();
            builder.HasMany(cv => cv.TabelaPrecos).WithOne(tp => tp.CanalVenda);
        }
    }
}
