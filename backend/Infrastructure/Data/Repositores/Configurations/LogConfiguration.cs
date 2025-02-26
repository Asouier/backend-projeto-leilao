using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.ProjetoLeilao.Infrastructure.Data.Repositores.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("log");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.UsuarioId)
                   .IsRequired()
                   .HasColumnName("usuario_id");

            builder.Property(l => l.ClienteId)
                   .HasColumnName("cliente_id");

            builder.Property(l => l.LeilaoId)
                   .HasColumnName("leilao_id");

            builder.Property(l => l.Entidade)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("entidade");

            builder.Property(l => l.EntidadeId)
                   .IsRequired()
                   .HasColumnName("entidade_id");

            builder.Property(l => l.DataHora)
                   .IsRequired()
                   .HasColumnName("data_hora")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.Acao)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("acao");

            builder.HasOne(l => l.Usuario)
                   .WithMany()
                   .HasForeignKey(l => l.UsuarioId);

            builder.HasOne(l => l.Cliente)
                   .WithMany()
                   .HasForeignKey(l => l.ClienteId);

            builder.HasOne(l => l.Leilao)
                   .WithMany()
                   .HasForeignKey(l => l.LeilaoId);
        }
    }
}
