using BikeRoubada.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRoubada.Data.Mappings
{
    public class RouboMapping : IEntityTypeConfiguration<Roubo>
    {
        public void Configure(EntityTypeBuilder<Roubo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NumeroBoletim)
                .IsRequired();

            builder.Property(e => e.DataRoubo) .IsRequired();
                       
            builder
                .HasOne(e => e.Bicicleta)
                .WithMany(e => e.Roubos)
                .HasForeignKey(e => e.IdBicicleta)
                .IsRequired();

            //builder
            //    .HasOne(e => e.Localizacao)
            //    .WithMany(e => e.Roubos)
            //    .HasForeignKey(e => e.IdLocalizacao)
            //    .IsRequired();

            builder.HasOne(e => e.Localizacao)
           .WithOne(e => e.Roubo) // <-- Linka a propriedade única
           .HasForeignKey<Roubo>(e => e.IdLocalizacao);

            builder.ToTable("Roubos");


        }
    }
}
