using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class TipoVeiculoConfiguration : IEntityTypeConfiguration<TipoVeiculo>
    {
        public void Configure(EntityTypeBuilder<TipoVeiculo> builder)
        {
            builder.ToTable("tipo_veiculo");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Descricao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("descricao");
        }
    }
}
