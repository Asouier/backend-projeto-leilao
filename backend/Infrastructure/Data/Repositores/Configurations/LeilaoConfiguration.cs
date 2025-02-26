using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.ProjetoLeilao.Infrastructure.Data.Repositores.Configurations
{
    public class LeilaoConfiguration : IEntityTypeConfiguration<Leilao>
    {
        public void Configure(EntityTypeBuilder<Leilao> builder)
        {
            builder.ToTable("leilao");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.TipoLeilaoId)
                   .IsRequired()
                   .HasColumnName("tipo_leilao_id");

            builder.Property(l => l.StatusId)
                   .IsRequired()
                   .HasColumnName("status_id");

            builder.Property(l => l.EnderecoId)
                   .IsRequired()
                   .HasColumnName("endereco_id");

            builder.Property(l => l.DataHoraInicio)
                   .IsRequired()
                   .HasColumnName("data_hora_inicio");

            builder.Property(l => l.DataHoraFim)
                   .IsRequired()
                   .HasColumnName("data_hora_fim");

            builder.Property(l => l.UrlLeilao)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("url_leilao");

            builder.Property(l => l.UsuarioCadastroId)
                   .IsRequired()
                   .HasColumnName("usuario_cadastro_id");

            builder.Property(l => l.UsuarioAprovacaoId)
                   .HasColumnName("usuario_aprovacao_id");

            builder.Property(l => l.TaxaAdministrativa)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("taxa_administrativa");

            builder.Property(l => l.ValorArrecadado)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("valor_arrecadado")
                   .HasDefaultValue(0m);

            builder.Property(l => l.DataHoraRegistro)
                   .IsRequired()
                   .HasColumnName("data_hora_registro")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(l => l.DataHoraAtualizacao)
                   .IsRequired()
                   .HasColumnName("data_hora_atualizacao")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(l => l.TipoLeilao)
                   .WithMany()
                   .HasForeignKey(l => l.TipoLeilaoId);

            builder.HasOne(l => l.Status)
                   .WithMany()
                   .HasForeignKey(l => l.StatusId);

            builder.HasOne(l => l.Endereco)
                   .WithMany()
                   .HasForeignKey(l => l.EnderecoId);

            builder.HasOne(l => l.UsuarioCadastro)
                   .WithMany()
                   .HasForeignKey(l => l.UsuarioCadastroId);

            builder.HasOne(l => l.UsuarioAprovacao)
                   .WithMany()
                   .HasForeignKey(l => l.UsuarioAprovacaoId);
        }
    }
}
