using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class StatusLeilaoConfiguration : IEntityTypeConfiguration<StatusLeilao>
    {
        public void Configure(EntityTypeBuilder<StatusLeilao> builder)
        {
            builder.ToTable("status_leilao");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Descricao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("descricao");
        }
    }
}
