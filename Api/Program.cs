using Application.IServices;
using Application.Services;
using Domain.Services;
using Infrastructure.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:8080") // O frontend
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "apiLeilao",
        Version = "v1",
        Description = "API de gerenciamento de leilões",
        Contact = new OpenApiContact
        {
            Name = "Leonardo Reis",
            Email = "leonardoreis.dev@gmail.com",
            Url = new Uri("https://github.com/Asouier")
        }
    });
});



builder.Services.AddControllers();

builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<ICredencialService, CredencialService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPermissaoService, PermissaoService>();
builder.Services.AddScoped<IRepresentanteLegalService, RepresentanteLegalService>();
builder.Services.AddScoped<IStatusPropriedadeService, StatusPropriedadeService>();
builder.Services.AddScoped<IStatusLeilaoService, StatusLeilaoService>();
builder.Services.AddScoped<ITipoImovelService, TipoImovelService>();
builder.Services.AddScoped<ITipoVeiculoService, TipoVeiculoService>();
builder.Services.AddScoped<ITipoLeilaoService, TipoLeilaoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "api-leilao");
        c.RoutePrefix = string.Empty; // Isso faz com que o Swagger UI abra em "http://localhost:5000/"
    });
}


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");

//app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();


app.Run();
