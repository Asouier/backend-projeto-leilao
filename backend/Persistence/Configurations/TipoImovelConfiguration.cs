using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Configurations
{
    public class TipoImovelConfiguration : IEntityTypeConfiguration<TipoImovel>
    {
        public void Configure(EntityTypeBuilder<TipoImovel> builder)
        {
            builder.ToTable("tipo_imovel");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Descricao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("descricao");
        }
    }
}
