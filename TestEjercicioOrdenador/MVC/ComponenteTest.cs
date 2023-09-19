using EjercicioOrdenador.Controllers;
using EjercicioOrdenador.CrossCutting.Logging;
using EjercicioOrdenador.Models;
using EjercicioOrdenador.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestEjercicioOrdenador.MVC
{
    [TestClass]
    public class ComponenteTest
    {
        private readonly ComponenteController _controlador = new(new FakeRepositorioComponentes(), 
            //new LoggerManager(), 
            new FakeRepositorioOrdenadores());

        [TestMethod]
        public void PruebaComponenteDetallesVistaEncontrada()
        {
            var result = _controlador.Details(2) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual("789-XCD", componente.Serie);
        }
        [TestMethod]
        public void PruebaComponenteDetallesVistaNoEncontrada()
        {
            var result = _controlador.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var componente = result.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreNotEqual("789-XCD", componente.Serie);
        }
        [TestMethod]
        public void PruebaComponentesIndexVistaOk()
        {
            var result = _controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaComponentes = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComponentes);
            Assert.AreEqual(18, listaComponentes.Count);
        }
        [TestMethod]
        public void PruebaComponentesIndexVistaNotOk()
        {
            var result = _controlador.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaComponentes = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComponentes);
            Assert.AreNotEqual(null, listaComponentes.Count);
        }
        [TestMethod]
        public void PruebaComponentesCreate()
        {
            var result = _controlador.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
        }
        [TestMethod]
        public void PruebaComponentesCreateWithParameters()
        {
            Componente componenteAnadido = new() { Id = 19, Serie = "1789-XCT", Description = "Disco Externo Sam", Calor = 22, Precio = 140, Cores = 0, Megas = 11264000, Tipo = EnumTipoComponente.Rom };
            var result = _controlador.Create(componenteAnadido, 0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaComponentes = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComponentes);
            Assert.AreEqual(19, listaComponentes.Count);
        }
        [TestMethod]
        public void PruebaComponentesEdit()
        {
            var result = _controlador.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
        }
        [TestMethod]
        public void PruebaComponentesEditWithParameters()
        {
            Componente componenteEditado = new() { Id = 1, Serie = "789-XCS", Description = "Procesador Intel i7", Calor = 11, Precio = 134, Cores = 9, Megas = 0, Tipo = EnumTipoComponente.Procesador, OrdenadorId = 0 };
            var result = _controlador.Edit(1, componenteEditado, 0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var resultEdited = _controlador.Details(1) as ViewResult;
            Assert.IsNotNull(resultEdited);
            var componente = resultEdited.ViewData.Model as Componente;
            Assert.IsNotNull(componente);
            Assert.AreEqual(11, componente.Calor);
        }
        [TestMethod]
        public void PruebaComponentesEditWithParametersNotOk()
        {
            Componente componenteEditado = new() { Id = 19, Serie = "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww", OrdenadorId = 1 };
            var result = _controlador.Edit(19, componenteEditado, 0) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.ViewName);
        }

        [TestMethod]
        public void PruebaComponentesDelete()
        {
            var result = _controlador.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
        }
        [TestMethod]
        public void PruebaComponentesDeleteConfirmed()
        {
            var result = _controlador.DeleteConfirmed(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaComponentes = result.ViewData.Model as List<Componente>;
            Assert.IsNotNull(listaComponentes);
            Assert.AreEqual(17, listaComponentes.Count);
        }
        [TestMethod]
        public void PruebaComponentesDeleteConfirmedNotOk()
        {
            var result = _controlador.DeleteConfirmed(19) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(null, result.ViewName);

        }
    }
}