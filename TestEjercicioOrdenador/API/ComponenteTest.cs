using EjercicioOrdenador.Services;
using Microsoft.AspNetCore.Mvc;
using WebApiOrdenadores.Controllers;
using WebApiOrdenadores.Models;

namespace TestEjercicioOrdenador.API
{
    [TestClass]
    public class ComponenteTest
    {
        private readonly ComponenteController _controlador = new(new FakeRepositorioComponentesAPI());

        [TestMethod]
        public void PruebaGet()
        {
            var result = _controlador.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(18, result.Count());
        }
        [TestMethod]
        public void PruebaGetById()
        {
            var result = _controlador.GetById(2);
            Assert.IsNotNull(result);
            Assert.AreEqual(138, result.Precio);
        }
        
        [TestMethod]
        public void PruebaPost()
        {
            _controlador.Post(new Componente() { Id = 19, Serie = "789-XCS", Description = "Procesador Intel i7", Calor = 10, Precio = 134, Cores = 9, Megas = 0, Tipo = EnumTipoComponente.Procesador });
            var result = _controlador.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(19, result.Count());
        }
        
        [TestMethod]
        public void PruebaPut()
        {
            _controlador.Put(new Componente() { Id = 18, Serie = "789-XCS", Description = "Procesador Intel i7", Calor = 100, Precio = 134, Cores = 9, Megas = 0, Tipo = EnumTipoComponente.Procesador }, 18);
            var result = _controlador.GetById(18);
            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.Calor);
        }
        [TestMethod]
        public void PruebaDelete()
        {
            _controlador.Delete(1);
            var result = _controlador.Get();
            Assert.IsNotNull(result);
            Assert.AreEqual(17, result.Count());
        }

    }
}