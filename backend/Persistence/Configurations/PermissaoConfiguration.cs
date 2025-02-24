using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Configurations
{
    public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("permissao");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("descricao");
        }
    }
}
