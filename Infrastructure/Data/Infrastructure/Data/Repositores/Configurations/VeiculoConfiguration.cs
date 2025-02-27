using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data.Repositores.Configurations
{
    public class VeiculoConfiguration : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculo");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.LeilaoId)
                   .IsRequired()
                   .HasColumnName("leilao_id");

            builder.Property(v => v.TipoVeiculoId)
                   .IsRequired()
                   .HasColumnName("tipo_veiculo_id");

            builder.Property(v => v.Placa)
                   .IsRequired()
                   .HasMaxLength(10)
                   .HasColumnName("placa");

            builder.Property(v => v.Chassi)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasColumnName("chassi");

            builder.Property(v => v.Marca)
                   .HasMaxLength(50)
                   .HasColumnName("marca");

            builder.Property(v => v.Modelo)
                   .HasMaxLength(50)
                   .HasColumnName("modelo");

            builder.Property(v => v.AnoFabricacao)
                   .HasColumnName("ano_fabricacao");

            builder.Property(v => v.Cor)
                   .HasMaxLength(30)
                   .HasColumnName("cor");

            builder.Property(v => v.ValorMinimo)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("valor_minimo");

            builder.Property(v => v.StatusPropriedadeId)
                   .IsRequired()
                   .HasColumnName("status_propriedade_id");

            builder.Property(v => v.DataHoraCadastro)
                   .IsRequired()
                   .HasColumnName("data_hora_cadastro")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(v => v.UsuarioCadastroId)
                   .IsRequired()
                   .HasColumnName("usuario_cadastro_id");

            builder.Property(v => v.DataRecolhimento)
                   .IsRequired()
                   .HasColumnName("data_recolhimento");

            builder.Property(v => v.MotivoRecolhimento)
                   .IsRequired()
                   .HasColumnName("motivo_recolhimento");

            builder.Property(v => v.ClienteArrematanteId)
                   .HasColumnName("cliente_arrematante_id");

            builder.HasOne(v => v.Leilao)
                   .WithMany()
                   .HasForeignKey(v => v.LeilaoId);

            builder.HasOne(v => v.TipoVeiculo)
                   .WithMany()
                   .HasForeignKey(v => v.TipoVeiculoId);

            builder.HasOne(i => i.Leilao)
                   .WithMany(l => l.Veiculos)
                   .HasForeignKey(i => i.LeilaoId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(v => v.StatusPropriedade)
                   .WithMany()
                   .HasForeignKey(v => v.StatusPropriedadeId);

            builder.HasOne(v => v.UsuarioCadastro)
                   .WithMany()
                   .HasForeignKey(v => v.UsuarioCadastroId);

            builder.HasOne(v => v.ClienteArrematante)
                   .WithMany()
                   .HasForeignKey(v => v.ClienteArrematanteId);
        }
    }
}
