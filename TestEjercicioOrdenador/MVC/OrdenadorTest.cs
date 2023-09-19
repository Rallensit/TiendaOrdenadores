using EjercicioOrdenador.Controllers;
using EjercicioOrdenador.Models;
using EjercicioOrdenador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestEjercicioOrdenador.MVC;

[TestClass]
public class OrdenadorTest
{
    private readonly OrdenadorController _controlador = new(new FakeRepositorioOrdenadores()
        //, new LoggerManager()
    );

    [TestMethod]
    public void PruebaOrdenadorDetallesVistaEncontrada()
    {
        var result = _controlador.Details(0) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Details", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var ordenador = result.ViewData.Model as Ordenador;
        Assert.IsNotNull(ordenador);
        Assert.AreEqual("Ordenador0", ordenador.Description);
    }
    [TestMethod]
    public void PruebaOrdenadorDetallesVistaNoEncontrada()
    {
        var result = _controlador.Details(1) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Details", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var ordenador = result.ViewData.Model as Ordenador;
        Assert.IsNotNull(ordenador);
        Assert.AreNotEqual("Ordenador0", ordenador.Description);
    }
    [TestMethod]
    public void PruebaOrdenadorIndexVistaOk()
    {
        var result = _controlador.Index() as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var listaOrdenadores = result.ViewData.Model as List<Ordenador>;
        Assert.IsNotNull(listaOrdenadores);
        Assert.AreEqual(2, listaOrdenadores.Count);
    }
    [TestMethod]
    public void PruebaOrdenadorIndexVistaNotOk()
    {
        var result = _controlador.Index() as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var listaOrdenadores = result.ViewData.Model as List<Ordenador>;
        Assert.IsNotNull(listaOrdenadores);
        Assert.AreNotEqual(null, listaOrdenadores.Count);
    }
    [TestMethod]
    public void PruebaOrdenadorCreate()
    {
        var result = _controlador.Create() as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Create", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
    }
    [TestMethod]
    public void PruebaComponentesCreateWithParameters()
    {
        Ordenador ordenadorAnadido = new() { Id = 2, Description = "Ordenador2" };
        var result = _controlador.Create(ordenadorAnadido) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var listaOrdenadores = result.ViewData.Model as List<Ordenador>;
        Assert.IsNotNull(listaOrdenadores);
        Assert.AreEqual(3, listaOrdenadores.Count);
    }
    [TestMethod]
    public void PruebaOrdenadorEdit()
    {
        var result = _controlador.Edit(1) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Edit", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
    }
    [TestMethod]
    public void PruebaComponentesEditWithParameters()
    {
        Ordenador ordenadorEditado = new() { Id = 0, Description = "Ordenador de Maria" };
        var result = _controlador.Edit(0, ordenadorEditado) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var resultEdited = _controlador.Details(0) as ViewResult;
        Assert.IsNotNull(resultEdited);
        var ordenador = resultEdited.ViewData.Model as Ordenador;
        Assert.IsNotNull(ordenador);
        Assert.AreEqual("Ordenador de Maria", ordenador.Description);
    }
    [TestMethod]
    public void PruebaOrdenadorDelete()
    {
        var result = _controlador.Delete(1) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Delete", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
    }
    [TestMethod]
    public void PruebaOrdenadorDeleteConfirmed()
    {
        var result = _controlador.DeleteConfirmed(1) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual("Index", result.ViewName);
        Assert.IsNotNull(result.ViewData.Model);
        var listaOrdenadores = result.ViewData.Model as List<Ordenador>;
        Assert.IsNotNull(listaOrdenadores);
        Assert.AreEqual(1, listaOrdenadores.Count);
    }
    [TestMethod]
    public void PruebaOrdenadorDeleteConfirmedNotOk()
    {
        var result = _controlador.DeleteConfirmed(19) as ViewResult;
        Assert.IsNotNull(result);
        Assert.AreEqual(null, result.ViewName);

    }
}