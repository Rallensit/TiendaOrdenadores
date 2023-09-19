using Microsoft.AspNetCore.Mvc;
using WebApiOrdenadores.Models;
using WebApiOrdenadores.Services;

namespace WebApiOrdenadores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdenadorController : Controller
{
    private readonly IRepositorioGenerico<Ordenador> _repositorio;

    public OrdenadorController(IRepositorioGenerico<Ordenador> repositorio)
    {
        _repositorio = repositorio;

    }

    // GET: Ordenador
    [HttpGet]
    public IEnumerable<Ordenador>? Get()
    {
        return _repositorio.Listar();
    }

    // GET: Ordenador
    [HttpGet("{id}")]
    public Ordenador? GetById(int id)
    {
        return _repositorio.Obtener(id);
    }

    // POST: Ordenador/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public void Post([FromBody] Ordenador c)
    {
        _repositorio.Anadir(c);
    }

    [HttpPut("{id}")]
    public void Put([FromBody] Ordenador c, int id)
    {
        _repositorio.Actualizar(id, c);
    }

    // POST: Ordenador/Delete/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _repositorio.Borrar(id);
    }

}