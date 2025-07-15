using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistencia;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CarritoContexto>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("ConexionDatabase"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexionDatabase")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
