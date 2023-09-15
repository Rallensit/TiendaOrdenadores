using EjercicioOrdenador.CrossCutting.Logging;
using EjercicioOrdenador.Data;
using EjercicioOrdenador.Models;
using Microsoft.EntityFrameworkCore;


namespace EjercicioOrdenador.Services;

public class RepositorioComponentes : IRepositorioComponente
{
    readonly TiendaOrdenadorContext _context;
    readonly ILoggerManager _logger;

    public RepositorioComponentes(ILoggerManager loggerManager, TiendaOrdenadorContext contexto)
    {
        _logger = loggerManager;
        _logger.LogInfo("Linked Log to repository");
        _context = contexto;
    }
    public void AddComponente(Componente? componente)
    {
        if (_context.Componentes is not null)
        {
            if (componente != null)
            {
                _context.Componentes.Add(componente);
                _logger.LogInfo($"Componente {componente.Id} añadido");
            }

            _context.SaveChanges();
        }
    }

    public void DeleteComponente(int id)
    {
        if (_context.Componentes is not null)
        {
            var componenteABorrar = GetComponente(id);
            if (componenteABorrar is not null)
            {
                _context.Componentes.Remove(componenteABorrar);
                _logger.LogInfo($"Componente eliminado");
                _context.SaveChanges();
            }
        }
    }

    public Componente? GetComponente(int id)
    {
        if (_context.Componentes != null)
            return _context.Componentes.Include(c => c.MiOrdenador).First(x => x.Id == id);
        return null;
    }

    public List<Componente>? ListaComponentes()
    {
        if (_context.Componentes != null)
        {
            return _context.Componentes.Include(c => c.MiOrdenador).ToList();
        }
        return null;
    }

    public void Update(int id, Componente componente)
    {
        if (_context.Componentes is not null)
        {
            var componenteEditar = GetComponente(id);
            if (componenteEditar is not null)
            {
                componenteEditar.Id = componente.Id;
                componenteEditar.Serie = componente.Serie;
                componenteEditar.Description = componente.Description;
                componenteEditar.Calor = componente.Calor;
                componenteEditar.Precio = componente.Precio;
                componenteEditar.Cores = componente.Cores;
                componenteEditar.Megas = componente.Megas;
                componenteEditar.Tipo = componente.Tipo;
                componenteEditar.OrdenadorId = componente.OrdenadorId;
                _context.SaveChanges();
            }
        }
    }
}