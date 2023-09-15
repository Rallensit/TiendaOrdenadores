using EjercicioOrdenador.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApiOrdenadores.Models;

namespace WebApiOrdenadores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponenteController : ControllerBase
    {
        private readonly IRepositorioComponente _repositorio;

        public ComponenteController(IRepositorioComponente repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: Componente
        [HttpGet]
        public IEnumerable<Componente>? Get()
        {
            return _repositorio.ListaComponentes();
        }

        // GET: Componente
        [HttpGet("{id}")]
        public Componente? GetById(int id)
        {
            return _repositorio.GetComponente(id);
        }

        // POST: Componente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void Post([FromBody] Componente c)
        {
            _repositorio.AddComponente(c);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Componente c, int id)
        {
            _repositorio.Update(id, c);
        }

        // POST: Componente/Delete/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repositorio.DeleteComponente(id);
        }
    }
}
