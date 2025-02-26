using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.ProjetoLeilao.Infrastructure.Data.Repositores.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.CredencialId)
                   .IsRequired()
                   .HasColumnName("credencial_id");

            builder.Property(u => u.DataHoraRegistro)
                   .IsRequired()
                   .HasColumnName("data_hora_registro")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(u => u.EntidadeResponsavel)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("entidade_responsavel");

            builder.Property(u => u.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("nome_completo");

            builder.Property(u => u.ContatoId)
                   .IsRequired()
                   .HasColumnName("contato_id");

            builder.Property(u => u.Cpf)
                   .IsRequired()
                   .HasMaxLength(14)
                   .HasColumnName("cpf");

            builder.Property(u => u.Rg)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnName("rg");

            builder.Property(u => u.CargoFuncao)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("cargo_funcao");

            builder.Property(u => u.PermissaoId)
                   .IsRequired()
                   .HasColumnName("permissao_id");

            builder.Property(u => u.UsuarioConcessaoId)
                   .HasColumnName("usuario_concessao_id");

            builder.Property(u => u.RegiaoResponsavel)
                   .HasMaxLength(100)
                   .HasColumnName("regiao_responsavel");

            builder.Property(u => u.CategoriaResponsavel)
                   .HasMaxLength(100)
                   .HasColumnName("categoria_responsavel");

            builder.HasOne(u => u.Credencial)
                   .WithMany()
                   .HasForeignKey(u => u.CredencialId);

            builder.HasOne(u => u.Contato)
                   .WithMany()
                   .HasForeignKey(u => u.ContatoId);

            builder.HasOne(u => u.Permissao)
                   .WithMany()
                   .HasForeignKey(u => u.PermissaoId);

            builder.HasOne(u => u.UsuarioConcessao)
                   .WithMany()
                   .HasForeignKey(u => u.UsuarioConcessaoId);
        }
    }
}
