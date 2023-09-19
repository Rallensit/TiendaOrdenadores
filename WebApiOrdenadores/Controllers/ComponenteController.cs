using Microsoft.AspNetCore.Mvc;
using WebApiOrdenadores.Models;

namespace WebApiOrdenadores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComponenteController : ControllerBase
{
    private readonly Services.IRepositorioGenerico<Componente> _repositorio;

    public ComponenteController(Services.IRepositorioGenerico<Componente> repositorio)
    {
        _repositorio = repositorio;
    }

    // GET: Componente
    [HttpGet]
    public IEnumerable<Componente>? Get()
    {
        return _repositorio.Listar();
    }

    // GET: Componente
    [HttpGet("{id}")]
    public Componente? GetById(int id)
    {
        return _repositorio.Obtener(id);
    }

    // POST: Componente/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public void Post([FromBody] Componente c)
    {
        _repositorio.Anadir(c);
    }

    [HttpPut("{id}")]
    public void Put([FromBody] Componente c, int id)
    {
        _repositorio.Actualizar(id, c);
    }

    // POST: Componente/Delete/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _repositorio.Borrar(id);
    }
}