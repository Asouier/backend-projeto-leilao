using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Configurations
{
    public class ImovelConfiguration : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.ToTable("imovel");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.TipoImovelId)
                   .IsRequired()
                   .HasColumnName("tipo_imovel_id");

            builder.Property(i => i.LeilaoId)
                   .IsRequired()
                   .HasColumnName("leilao_id");

            builder.Property(i => i.EnderecoId)
                   .IsRequired()
                   .HasColumnName("endereco_id");

            builder.Property(i => i.AreaTotal)
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("area_total");

            builder.Property(i => i.QuantidadeComodos)
                   .HasColumnName("quantidade_comodos");

            builder.Property(i => i.ValorMinimo)
                   .IsRequired()
                   .HasColumnType("decimal(10,2)")
                   .HasColumnName("valor_minimo");

            builder.Property(i => i.StatusPropriedadeId)
                   .IsRequired()
                   .HasColumnName("status_propriedade_id");

            builder.Property(i => i.DataHoraCadastro)
                   .IsRequired()
                   .HasColumnName("data_hora_cadastro")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(i => i.UsuarioCadastroId)
                   .IsRequired()
                   .HasColumnName("usuario_cadastro_id");

            builder.Property(i => i.DataRecolhimento)
                   .IsRequired()
                   .HasColumnName("data_recolhimento");

            builder.Property(i => i.MotivoRecolhimento)
                   .IsRequired()
                   .HasColumnName("motivo_recolhimento");

            builder.Property(i => i.ClienteArrematanteId)
                   .HasColumnName("cliente_arrematante_id");

            // Relacionamentos
            builder.HasOne(i => i.TipoImovel)
                   .WithMany()
                   .HasForeignKey(i => i.TipoImovelId);

            builder.HasOne(i => i.Leilao)
                   .WithMany()
                   .HasForeignKey(i => i.LeilaoId);

            builder.HasOne(i => i.Endereco)
                   .WithMany()
                   .HasForeignKey(i => i.EnderecoId);

            builder.HasOne(i => i.StatusPropriedade)
                   .WithMany()
                   .HasForeignKey(i => i.StatusPropriedadeId);

            builder.HasOne(i => i.UsuarioCadastro)
                   .WithMany()
                   .HasForeignKey(i => i.UsuarioCadastroId);

            builder.HasOne(i => i.ClienteArrematante)
                   .WithMany()
                   .HasForeignKey(i => i.ClienteArrematanteId);
        }
    }
}
