using EjercicioOrdenador.Models;
using EjercicioOrdenador.Services;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioOrdenador.Controllers;

public class OrdenadorController : Controller
{
    private readonly IRepositorioGenerico<Ordenador> _repositorio;
    //private readonly ILoggerManager _loggerManager;

    public OrdenadorController(IRepositorioGenerico<Ordenador> repositorio
        // ,ILoggerManager loggerManager
    )
    {
        _repositorio = repositorio;
        // _loggerManager = loggerManager;
    }

    // GET: Ordenador
    public ActionResult Index()
    {
        //  _loggerManager.LogInfo("Se va a mostrar la lista de ordenadores");
        return View("Index", _repositorio.Listar());
    }

    // GET: Ordenador/Details/5
    public ActionResult Details(int id)
    {
        //  _loggerManager.LogInfo("Se va a mostrar los detalles del ordenador " + id);
        return View("Details", _repositorio.Obtener(id));
    }

    // GET: Ordenador/Create
    public IActionResult Create()
    {
        // _loggerManager.LogInfo("Se va a mostrar la vista para crear un nuevo ordenador");
        return View("Create", new Ordenador());
    }

    // POST: Ordenador/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind("Id,Componentes,Description")] Ordenador ordenador)
    {
        _repositorio.Anadir(ordenador);
        //  _loggerManager.LogInfo("Se ha creado un nuevo ordenador " + ordenador.Id);
        return View("Index", _repositorio.Listar());
    }

    // GET: Ordenador/Edit/5
    public ActionResult Edit(int id)
    {
        //  _loggerManager.LogInfo("Se va a mostrar la vista para editar el ordenador " + id);
        return View("Edit", _repositorio.Obtener(id));
    }

    // POST: Ordenador/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, [Bind("Id,Componentes,Description")] Ordenador ordenador)
    {
        try
        {
            var ordenadorEncotrado = _repositorio.Obtener(id);
            if (ordenadorEncotrado != null)
            {
                _repositorio.Actualizar(id, ordenador);
            }
            //   _loggerManager.LogInfo("Se esta editando el ordenador " + id);
            return View("Index", _repositorio.Listar());
        }
        catch
        {
            //    _loggerManager.LogError("No se ha podido editar el ordenador " + id);
            return View();
        }

    }

    // GET: Ordenador/Delete/5
    public ActionResult Delete(int id)
    {
        //  _loggerManager.LogInfo("Se va a mostrar la vista para eliminar el ordenador " + id);
        return View("Delete", _repositorio.Obtener(id));
    }

    // POST: Ordenador/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            var componenteEncotrado = _repositorio.Obtener(id);
            if (componenteEncotrado != null)
            {
                _repositorio.Borrar(id);
                //        _loggerManager.LogInfo("Se esta eliminando el ordenador " + id);
            }
            return View("Index", _repositorio.Listar());
        }
        catch
        {
            //    _loggerManager.LogWarn("No se ha podido eliminar el ordenador " + id);
            return View();
        }
    }
}