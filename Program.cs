using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RDLSuperMarket.Model;
using RDLSuperMarket.Repositorio;
using RDLSuperMarket.ORM;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicione o contexto do banco de dados
builder.Services.AddDbContext<RdlsuperMarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<ClienteR>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Removido o middleware de autenticação e autorização
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
