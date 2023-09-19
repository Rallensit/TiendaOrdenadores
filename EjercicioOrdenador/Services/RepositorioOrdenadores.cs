using EjercicioOrdenador.CrossCutting.Logging;
using EjercicioOrdenador.Data;
using EjercicioOrdenador.Models;

namespace EjercicioOrdenador.Services;

public class RepositorioOrdenadores : IRepositorioGenerico<Ordenador>
{
    private readonly TiendaOrdenadorContext _context;
    private readonly ILoggerManager _logger;

    public RepositorioOrdenadores(ILoggerManager loggerManager, TiendaOrdenadorContext contexto)
    {
        _logger = loggerManager;
        _logger.LogInfo("Linked Log to repository");
        _context = contexto;
    }

    public void Anadir(Ordenador ordenador)
    {
        if (_context.Ordenadores is not null)
        {
            _context.Ordenadores.Add(ordenador);
            _logger.LogInfo($"Ordenador {ordenador.Id} añadido");
            _context.SaveChanges();
        }
    }

    public void Borrar(int id)
    {
        if (_context.Ordenadores is not null)
        {
            var ordenadorABorrar = Obtener(id);
            if (ordenadorABorrar is not null)
            {
                _context.Ordenadores.Remove(ordenadorABorrar);
            }
        }
    }

    public Ordenador? Obtener(int id)
    {
        if (_context.Ordenadores is not null)
        {
            return _context.Ordenadores.First(x => x.Id == id);
        }
        return null;
    }

    public List<Ordenador>? Listar()
    {
        if (_context.Ordenadores != null)
        {
            Console.WriteLine(_context.Ordenadores.ToList());
            return _context.Ordenadores.ToList();
        }
        return null;
    }

    public void Actualizar(int id, Ordenador ordenador)
    {
        if (_context.Componentes is not null)
        {
            var ordenadorEditar = Obtener(id);
            if (ordenadorEditar is not null)
            {
                ordenadorEditar.Id = ordenador.Id;
                ordenadorEditar.Description = ordenador.Description;
                ordenadorEditar.Componentes = ordenador.Componentes;
                _context.SaveChanges();
            }
        }
    }
}