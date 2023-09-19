using EjercicioOrdenador.Models;
using EjercicioOrdenador.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EjercicioOrdenador.Controllers;

public class ComponenteController : Controller
{
    private readonly IRepositorioGenerico<Componente> _repositorio;
    private readonly IRepositorioGenerico<Ordenador> _repositorioOrdenador;
    //private readonly ILoggerManager _loggerManager;

    public ComponenteController(IRepositorioGenerico<Componente> repositorio,
        //  ILoggerManager loggerManager, 
        IRepositorioGenerico<Ordenador> repositorioOrdenador)
    {
        _repositorio = repositorio;
        _repositorioOrdenador = repositorioOrdenador;
        //_loggerManager = loggerManager;
        //_loggerManager.LogDebug("For Testing");
    }

    public ActionResult LandingPage()
    {
        return View("LandingPage", _repositorio.Listar());
    }

    // GET: Componente
    public ActionResult Index()
    {
        //_loggerManager.LogInfo("Se va a mostrar la lista de componentes");
        return View("Index", _repositorio.Listar());
    }

    // GET: Componente/Details/5
    public ActionResult Details(int id)
    {
        // _loggerManager.LogInfo("Se va a mostrar los detalles del componente " + id);
        return View("Details", _repositorio.Obtener(id));
    }

    // GET: Componente/Create
    public ActionResult Create()
    {
        ViewBag.TipoList = Enum.GetValues(typeof(EnumTipoComponente)).Cast<EnumTipoComponente>().Select(v => new SelectListItem
        {
            Text = v.ToString(),
            Value = ((int)v).ToString()
        }).ToList();

        ViewBag.OrdenadoresId = _repositorioOrdenador.Listar() ?? new List<Ordenador>();

        //_loggerManager.LogInfo("Se va a mostrar la vista para crear un nuevo componente");
        return View("Create", new Componente());
    }

    // POST: Componente/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind("Id,Serie,Description,Calor,Precio,Cores,Megas,Tipo")] Componente? componente, int ordenadorId)
    {
        if (componente != null)
        {
            componente.OrdenadorId = ordenadorId;
            _repositorio.Anadir(componente);
        }

        // if (componente != null) _loggerManager.LogInfo("Se ha creado un nuevo componente " + componente.Id);
        return View("Index", _repositorio.Listar());
    }

    // GET: Componente/Edit/5
    public ActionResult Edit(int id)
    {
        ViewBag.TipoList = Enum.GetValues(typeof(EnumTipoComponente))
            .Cast<EnumTipoComponente>()
            .Select(v => new SelectListItem
            {
                Text = v.ToString(),
                Value = ((int)v).ToString()
            }).ToList();

        ViewBag.OrdenadoresId = _repositorioOrdenador.Listar() ?? new List<Ordenador>();

        // _loggerManager.LogInfo("Se va a mostrar la vista para editar el componente " + id);
        return View("Edit", _repositorio.Obtener(id));
    }

    // POST: Componente/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, [Bind("Id,Serie,Description,Calor,Precio,Cores,Megas,Tipo")] Componente componente, int ordenadorId)
    {
        try
        {
            var componenteEncontrado = _repositorio.Obtener(id);
            if (componenteEncontrado != null)
            {
                componente.OrdenadorId = ordenadorId;
                _repositorio.Actualizar(id, componente);
            }
            //    _loggerManager.LogInfo("Se esta editando el componente " + id);
            return View("Index", _repositorio.Listar());
        }
        catch
        {
            //    _loggerManager.LogError("No se ha podido editar el componente " + id);
            return View();
        }

    }

    // GET: Componente/Delete/5
    public ActionResult Delete(int id)
    {
        // _loggerManager.LogInfo("Se va a mostrar la vista para eliminar el componente " + id);
        return View("Delete", _repositorio.Obtener(id));
    }

    // POST: Componente/Delete/5
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
                //    _loggerManager.LogInfo("Se esta eliminando el componente " + id);
            }
            return View("Index", _repositorio.Listar());
        }
        catch
        {
            // _loggerManager.LogWarn("No se ha podido eliminar el componente " + id);
            return View();
        }
    }

}