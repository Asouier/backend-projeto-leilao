using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Persistence.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cep)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasColumnName("cep");

            builder.Property(e => e.Descricao)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("descricao");

            builder.Property(e => e.Cidade)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("cidade");

            builder.Property(e => e.Estado)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("estado");

            builder.Property(e => e.Pais)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("pais");

            builder.Property(e => e.Numero)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasColumnName("numero");

            builder.Property(e => e.Complemento)
                   .HasMaxLength(255)
                   .HasColumnName("complemento");
        }
    }
}
