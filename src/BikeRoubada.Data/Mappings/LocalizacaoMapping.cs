using BikeRoubada.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRoubada.Data.Mappings
{
    internal class LocalizacaoMapping : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Rua)
                .HasColumnType("varchar(100)")
                .IsRequired();
            
            builder.Property(e => e.Estado)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(e => e.Coordenadas)
                .HasColumnType("point");

            builder.ToTable("Localizacao");
        }
    }
}
