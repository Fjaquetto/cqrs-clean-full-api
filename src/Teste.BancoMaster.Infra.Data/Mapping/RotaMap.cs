using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.BancoMaster.Domain.Models;

namespace Teste.BancoMaster.Infra.Data.Mapping
{
    public class RotaMap : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Origem)
                .IsRequired()
                .HasColumnType("varchar(3)")
                .HasMaxLength(3);

            builder.Property(c => c.Destino)
                .IsRequired()
                .HasColumnType("varchar(3)")
                .HasMaxLength(3);

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(18,2)");

            builder.ToTable("Carros");

        }
    }
}
