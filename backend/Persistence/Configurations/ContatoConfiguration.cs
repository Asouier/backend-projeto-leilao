using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Configurations
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

            // Índice único para email
            builder.HasIndex(c => c.Email)
                   .IsUnique();
        }
    }
}
