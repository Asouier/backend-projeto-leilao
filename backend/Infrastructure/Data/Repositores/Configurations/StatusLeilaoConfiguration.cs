using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.ProjetoLeilao.Infrastructure.Data.Repositores.Configurations
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
