using DotNetEnv;
using EjercicioOrdenador.Services;

namespace WebApiOrdenadores
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddScoped<IRepositorioComponente, RepositorioComponentesAPI>();
            builder.Services.AddScoped<IRepositorioOrdenador, RepositorioOrdenadoresAPI>();
            //builder.Services.AddScoped<IRepositorioComponente, FakeRepositorioComponentesAPI>();
            //builder.Services.AddScoped<IRepositorioOrdenador, FakeRepositorioOrdenadoresAPI>();

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
}