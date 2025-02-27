using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositores
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabelas do sistema
        public DbSet<Endereco> Enderecos => Set<Endereco>();
        public DbSet<StatusPropriedade> StatusPropriedades => Set<StatusPropriedade>();
        public DbSet<TipoImovel> TiposImovel => Set<TipoImovel>();
        public DbSet<Imovel> Imoveis => Set<Imovel>();
        public DbSet<TipoVeiculo> TiposVeiculo => Set<TipoVeiculo>();
        public DbSet<Veiculo> Veiculos => Set<Veiculo>();
        public DbSet<TipoLeilao> TiposLeilao => Set<TipoLeilao>();
        public DbSet<StatusLeilao> StatusLeiloes => Set<StatusLeilao>();
        public DbSet<Leilao> Leiloes => Set<Leilao>();
        public DbSet<Credencial> Credenciais => Set<Credencial>();
        public DbSet<Contato> Contatos => Set<Contato>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<RepresentanteLegal> RepresentantesLegais => Set<RepresentanteLegal>();
        public DbSet<Permissao> Permissoes => Set<Permissao>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Log> Logs => Set<Log>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define o schema padrão
            modelBuilder.HasDefaultSchema("app");

            // Aplica configurações de entidades a partir do assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}