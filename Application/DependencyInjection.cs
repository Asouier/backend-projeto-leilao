using Application.IServices;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Data.Persistence;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptions =>
                    {
                        sqlServerOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                        sqlServerOptions.CommandTimeout(60);
                    }
                    ));

            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<ICredencialRepository, CredencialRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IRepresentanteLegalRepository, RepresentanteLegalRepository>();
            services.AddScoped<IStatusPropriedadeRepository, StatusPropriedadeRepository>();
            services.AddScoped<IStatusLeilaoRepository, StatusLeilaoRepository>();
            services.AddScoped<ITipoImovelRepository, TipoImovelRepository>();
            services.AddScoped<ITipoVeiculoRepository, TipoVeiculoRepository>();
            services.AddScoped<ITipoLeilaoRepository, TipoLeilaoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IImovelRepository, ImovelRepository>();
            services.AddScoped<ILeilaoRepository, LeilaoRepository>();

            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IContatoService, ContatoService>();
            services.AddScoped<ICredencialService, CredencialService>();
            services.AddScoped<IPermissaoService, PermissaoService>();
            services.AddScoped<IRepresentanteLegalService, RepresentanteLegalService>();
            services.AddScoped<IStatusPropriedadeService, StatusPropriedadeService>();
            services.AddScoped<IStatusLeilaoService, StatusLeilaoService>();
            services.AddScoped<ITipoImovelService, TipoImovelService>();
            services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();
            services.AddScoped<ITipoLeilaoService, TipoLeilaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IImovelService, ImovelService>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<ILeilaoService, LeilaoService>();

            return services;
        }
    }
}
