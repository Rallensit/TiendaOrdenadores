using EjercicioOrdenador.CrossCutting.Logging;
using EjercicioOrdenador.Data;
using EjercicioOrdenador.Models;
using EjercicioOrdenador.Services;
using Microsoft.EntityFrameworkCore;

namespace TestEjercicioOrdenador.MVC.Data;

[TestClass]
public class TiendaOrdenadorContextTests
{
    [TestMethod]
    public void TestAddAndDeleteOrdenadorComponent()
    {
        Componente? resultComponente;
        Ordenador? resultOrdenador;
        LoggerManager logger = new();

        var options = new DbContextOptionsBuilder<TiendaOrdenadorContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;

        var context = new TiendaOrdenadorContext(options);
        var repositoryComponentes = new RepositorioComponentes(logger, context);
        var repositoryOrdenadores = new RepositorioOrdenadores(logger, context);

        if (context is { Componentes: not null, Ordenadores: not null })
        {
            context.Ordenadores.Add(new Ordenador()
            {
                Id = 10000,
                Description = "Ordenador"
            });
            context.Componentes.Add(new Componente()
            {
                Id = 10000,
                Serie = "Test",
                Description = "Disco Externo Sam",
                Calor = 22,
                Precio = 140,
                Cores = 0,
                Megas = 11264000,
                Tipo = EnumTipoComponente.Rom,
                OrdenadorId = 10000
            });
            context.SaveChanges();
        }

        resultComponente = repositoryComponentes.Obtener(10000);
        resultOrdenador = repositoryOrdenadores.Obtener(10000);
        if (resultComponente != null) Assert.AreEqual("Test", resultComponente.Serie);
        if (resultOrdenador != null) Assert.AreEqual("Ordenador", resultOrdenador.Description);

        repositoryComponentes.Borrar(10000);
        repositoryOrdenadores.Borrar(10000);
    }
}