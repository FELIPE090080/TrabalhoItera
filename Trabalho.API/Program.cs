using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Trabalho.API.Repositorio;
using Trabalho.Aplicacao;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner
builder.Services.AddScoped<IAdministradorAplicacao, AdministradorAplicacao>();
builder.Services.AddScoped<IClienteAplicacao, ClienteAplicacao>();
builder.Services.AddScoped<ILoteAplicacao, LoteAplicacao>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione as interfaces de banco de dados
builder.Services.AddScoped<IAdministradorRepositorio, AdministradorRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ILoteRepositorio, LoteRepositorio>();

builder.Services.AddControllers();

// Adicionar os serviços ao banco de dados
builder.Services.AddDbContext<TrabalhoContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração de cultura
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var app = builder.Build();

// Configurando o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();