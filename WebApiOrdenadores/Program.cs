using WebApiOrdenadores.Models;
using WebApiOrdenadores.Services;

namespace WebApiOrdenadores;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
            
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddScoped<IRepositorioGenerico<Componente>, RepositorioComponentesApi>();
        builder.Services.AddScoped<IRepositorioGenerico<Ordenador>, RepositorioOrdenadoresApi>();
        //builder.Services.AddScoped<IRepositorioGenerico<Componente>, FakeRepositorioComponentesAPI>();
        //builder.Services.AddScoped<IRepositorioGenerico<Ordenador>, FakeRepositorioOrdenadoresAPI>();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}