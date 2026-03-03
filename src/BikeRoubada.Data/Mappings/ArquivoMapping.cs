using BikeRoubada.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BikeRoubada.Data.Mappings
{
    public class ArquivoMapping : IEntityTypeConfiguration<Arquivo>
    {
        public void Configure(EntityTypeBuilder<Arquivo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.NomeArquivo)
                .HasColumnType("varchar(50)")
                .IsRequired();

            // Configuração para Roubo (Já existente)
            builder.HasOne(e => e.Roubo)
                .WithMany(e => e.Arquivos)
                .HasForeignKey(e => e.IdRoubo)
                .IsRequired(false);

            // ADICIONE ESTA CONFIGURAÇÃO PARA BICICLETA
            builder.HasOne(e => e.Bicicleta)
                .WithMany(e => e.Arquivos)
                .HasForeignKey(e => e.IdBicicleta)
                .IsRequired(false); // Aqui garantimos que pode ser NULL no mapeamento

            // Force as propriedades de FK a aceitarem NULL explicitamente
            builder.Property(e => e.IdRoubo).IsRequired(false);
            builder.Property(e => e.IdBicicleta).IsRequired(false);

            builder.ToTable("Arquivos");
        }
    }
}
