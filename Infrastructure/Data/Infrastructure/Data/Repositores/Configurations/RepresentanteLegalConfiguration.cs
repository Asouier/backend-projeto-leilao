using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Repositores.Configurations
{
    public class RepresentanteLegalConfiguration : IEntityTypeConfiguration<RepresentanteLegal>
    {
        public void Configure(EntityTypeBuilder<RepresentanteLegal> builder)
        {
            builder.ToTable("representante_legal");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Nome)
                   .HasMaxLength(255)
                   .HasColumnName("nome");

            builder.Property(r => r.Cpf)
                   .HasMaxLength(14)
                   .HasColumnName("cpf");

            builder.Property(r => r.DocumentoIdentificacao)
                   .HasMaxLength(255)
                   .HasColumnName("documento_identificacao");

            builder.Property(r => r.ContatoId)
                   .HasColumnName("contato_id");

            builder.HasOne(r => r.Contato)
                   .WithMany()
                   .HasForeignKey(r => r.ContatoId);
        }
    }
}
