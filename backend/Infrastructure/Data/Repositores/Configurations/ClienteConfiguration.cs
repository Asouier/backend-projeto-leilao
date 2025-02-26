using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.ProjetoLeilao.Infrastructure.Data.Repositores.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.CredencialId)
                   .HasColumnName("credencial_id");

            builder.Property(c => c.DataHoraCadastro)
                   .IsRequired()
                   .HasColumnName("data_hora_cadastro")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Rg)
                   .HasMaxLength(20)
                   .HasColumnName("rg");

            builder.Property(c => c.OrgaoEmissor)
                   .HasMaxLength(50)
                   .HasColumnName("orgao_emissor");

            builder.Property(c => c.Cpf)
                   .HasMaxLength(14)
                   .HasColumnName("cpf");

            builder.Property(c => c.Cnpj)
                   .HasMaxLength(18)
                   .HasColumnName("cnpj");

            builder.Property(c => c.NomeCompleto)
                   .HasMaxLength(255)
                   .HasColumnName("nome_completo");

            builder.Property(c => c.NomeFantasia)
                   .HasMaxLength(100)
                   .HasColumnName("nome_fantasia");

            builder.Property(c => c.RazaoSocial)
                   .HasMaxLength(255)
                   .HasColumnName("razao_social");

            builder.Property(c => c.RepresentanteLegalId)
                   .HasColumnName("representante_legal_id");

            builder.Property(c => c.EnderecoId)
                   .IsRequired()
                   .HasColumnName("endereco_id");

            builder.Property(c => c.ContatoId)
                   .IsRequired()
                   .HasColumnName("contato_id");

            builder.Property(c => c.Certidao)
                   .HasMaxLength(255)
                   .HasColumnName("certidao");

            builder.HasOne(c => c.Credencial)
                   .WithMany()
                   .HasForeignKey(c => c.CredencialId);

            builder.HasOne(c => c.RepresentanteLegal)
                   .WithMany()
                   .HasForeignKey(c => c.RepresentanteLegalId);

            builder.HasOne(c => c.Endereco)
                   .WithMany()
                   .HasForeignKey(c => c.EnderecoId);

            builder.HasOne(c => c.Contato)
                   .WithMany()
                   .HasForeignKey(c => c.ContatoId);
        }
    }
}
