using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using EjercicioOrdenador.Services;
using WebApiOrdenadores.Models;
using NuGet.Protocol.Core.Types;

namespace WebApiOrdenadores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenadorController : Controller
    {
        private readonly IRepositorioOrdenador _repositorio;

        public OrdenadorController(IRepositorioOrdenador repositorio)
        {
            _repositorio = repositorio;

        }

        // GET: Ordenador
        [HttpGet]
        public IEnumerable<Ordenador> Get()
        {
            return _repositorio.ListaOrdenadores();
        }

        // GET: Ordenador
        [HttpGet("{id}")]
        public Ordenador GetById(int id)
        {
            return _repositorio.GetOrdenador(id);
        }

        // POST: Ordenador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void Post([FromBody] Ordenador c)
        {
            _repositorio.AddOrdenador(c);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Ordenador c, int id)
        {
            _repositorio.Update(id, c);
        }

        // POST: Ordenador/Delete/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repositorio.DeleteOrdenador(id);
        }

    }
}
