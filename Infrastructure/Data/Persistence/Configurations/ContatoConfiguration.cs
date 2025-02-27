using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("contato");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("email");

            builder.Property(c => c.Telefone)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnName("telefone");

            builder.HasIndex(c => c.Email)
                   .IsUnique();
        }
    }
}
