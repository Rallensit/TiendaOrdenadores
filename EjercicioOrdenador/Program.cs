using Azure.Storage.Blobs;
using DotNetEnv;
using EjercicioOrdenador.Data;
using EjercicioOrdenador.Models;
using EjercicioOrdenador.Services;
using EjercicioOrdenador.Services.API;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;

namespace EjercicioOrdenador;

public class Program
{
    protected Program() { }

    public static void Main(string[] args)
    {
        //ProcessAsync().GetAwaiter().GetResult();
        var builder = WebApplication.CreateBuilder(args);

        Env.Load();

        string? connectionString = Environment.GetEnvironmentVariable("AZURE_DATABASE");

        builder.Services.AddDbContext<TiendaOrdenadorContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString!)));

        //LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        //builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

        builder.Services.AddScoped<IRepositorioGenerico<Componente>, RepositorioComponentesApi>();
        builder.Services.AddScoped<IRepositorioGenerico<Ordenador>, RepositorioOrdenadoresApi>();
        //builder.Services.AddScoped<IRepositorioGenerico<Componente>, FakeRepositorioComponentes>();
        //builder.Services.AddScoped<IRepositorioGenerico<Ordenador>, FakeRepositorioOrdenadores>();
        //builder.Services.AddScoped<IRepositorioGenerico<Componente>, RepositorioComponentes>();
        //builder.Services.AddScoped<IRepositorioGenerico<Ordenador>, RepositorioOrdenadores>();


        builder.Services.AddHttpClient("MyHttpClient").AddPolicyHandler(GetCircuitBreakerPolicy());

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Componente}/{action=LandingPage}/{id?}");

        app.Run();
    }

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(
                handledEventsAllowedBeforeBreaking: 3, // N�mero de intentos antes de abrir el circuito
                durationOfBreak: TimeSpan.FromSeconds(30) // Duraci�n de la apertura del circuito en segundos
            );
    }

    static async Task ProcessAsync()
    {
        string containerName = "tiendaordenadores"; // Reemplaza con el nombre de tu contenedor
        string localFolderPath = "Logs";
        // Copy the connection string from the portal in the variable below.
        Env.Load();

        string? connectionString = Environment.GetEnvironmentVariable("AZURE_CONNECTION");

        // Create a client that can authenticate with a connection string
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        Console.WriteLine("Subiendo archivos a Azure Blob Storage...");

        // Lista todos los archivos en la carpeta local
        string[] files = Directory.GetFiles(localFolderPath);

        foreach (string filePath in files)
        {
            string blobName = "Logs/" + Path.GetFileName(filePath); // Directorio + nombre de archivo en Azure

            // Abre el archivo local
            await using (FileStream fileStream = File.OpenRead(filePath))
            {
                // Sube el archivo a Azure Blob Storage
                BlobClient blobClient = containerClient.GetBlobClient(blobName);
                await blobClient.UploadAsync(fileStream, true);
                fileStream.Close();
            }

            Console.WriteLine($"Archivo {Path.GetFileName(filePath)} subido.");
        }

        Console.WriteLine("Todos los archivos han sido subidos a Azure Blob Storage.");

    }

}