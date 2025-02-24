using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Backend.Persistence.Configurations
{
    public class CredencialConfiguration : IEntityTypeConfiguration<Credencial>
    {
        public void Configure(EntityTypeBuilder<Credencial> builder)
        {
            builder.ToTable("credencial");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeUsuario)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("nome_usuario");

            builder.Property(c => c.Senha)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("senha");

            // Índice único para nome de usuário
            builder.HasIndex(c => c.NomeUsuario)
                   .IsUnique();
        }
    }
}
