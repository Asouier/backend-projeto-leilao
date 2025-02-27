﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Domain.Entities;

namespace Backend.ProjetoLeilao.Infrastructure.Data.Repositores.Configurations
{
    public class TipoLeilaoConfiguration : IEntityTypeConfiguration<TipoLeilao>
    {
        public void Configure(EntityTypeBuilder<TipoLeilao> builder)
        {
            builder.ToTable("tipo_leilao");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Descricao)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("descricao");
        }
    }
}
