using Dominio.Infraestructura.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Dominio.Aplicacion.Interfaces;
using Dominio.Aplicacion.Services;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Inicia Servicio");
// Add services to the container.
builder.Services.AddLogging(builder => builder.AddConsole());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

MysqlContext validate = new MysqlContext(builder.Configuration.GetConnectionString("ConexionDatabase"));
/*if (!validate.Validate())
{
    Console.Error.WriteLine("No se puede conectar a la base de datos");
    return;
}*/

Console.WriteLine($"Inicia configuracion DB {builder.Configuration.GetConnectionString("ConexionDatabase")}");
builder.Services.AddDbContext<MysqlContext>(
      options =>
      {
          options.UseMySQL(builder.Configuration.GetConnectionString("ConexionDatabase"));
      }
      );


builder.Services.AddScoped<IUserService, userService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
