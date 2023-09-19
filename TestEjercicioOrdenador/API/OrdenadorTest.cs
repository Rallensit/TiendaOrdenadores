using WebApiOrdenadores.Controllers;
using WebApiOrdenadores.Models;
using WebApiOrdenadores.Services;

namespace TestEjercicioOrdenador.API;

[TestClass]
public class OrdenadorTest
{
    private readonly OrdenadorController _controlador = new(new FakeRepositorioOrdenadoresApi());

    [TestMethod]
    public void PruebaGet()
    {
        var result = _controlador.Get();
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }
    [TestMethod]
    public void PruebaGetById()
    {
        var result = _controlador.GetById(0);
        Assert.IsNotNull(result);
        Assert.AreEqual("Ordenador0", result.Description);
    }

    [TestMethod]
    public void PruebaPost()
    {
        _controlador.Post(new Ordenador() { Id = 2, Description = "Ordenador2"});
        var result = _controlador.Get();
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public void PruebaPut()
    {
        var resultAntes = _controlador.GetById(1);
        Assert.IsNotNull(resultAntes);
        Assert.AreEqual("Ordenador1", resultAntes.Description);
        _controlador.Put(new Ordenador() {Id = 1, Description = "Ordenador01" }, 1);
        var result = _controlador.GetById(1);
        Assert.IsNotNull(result);
        Assert.AreEqual("Ordenador01", result.Description);
    }
    [TestMethod]
    public void PruebaDelete()
    {
        _controlador.Delete(1);
        var result = _controlador.Get();
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count());
    }
}