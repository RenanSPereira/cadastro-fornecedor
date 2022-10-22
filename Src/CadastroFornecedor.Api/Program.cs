using CadastroFornecedor.Api.Configuration;
using CadastroFornecedor.Api.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AdicionarConfiguracaoSwagger();

//configuracao banco de dados
var conexao = builder.Configuration.GetConnectionString("FornecedorConnection");
builder.Services.AddDbContext<CadastroFornecedorContext>(options => options.UseSqlite(conexao));

builder.Services.ConfiguraDependencias();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
