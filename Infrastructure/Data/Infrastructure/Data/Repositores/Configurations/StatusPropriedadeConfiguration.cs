using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Repositores.Configurations
{
    public class StatusPropriedadeConfiguration : IEntityTypeConfiguration<StatusPropriedade>
    {
        public void Configure(EntityTypeBuilder<StatusPropriedade> builder)
        {
            builder.ToTable("status_propriedade");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Descricao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("descricao");
        }
    }
}
