using EjercicioOrdenador.Models;

namespace EjercicioOrdenador.Services;

public class FakeRepositorioOrdenadores : IRepositorioGenerico<Ordenador>
{
    private readonly List<Ordenador> _ordenadores = new();

    public FakeRepositorioOrdenadores()
    {
        _ordenadores.Add(new Ordenador() { Id = 0, Description = "Ordenador0" });
        _ordenadores.Add(new Ordenador() { Id = 1, Description = "Ordenador1" });
    }

    public void Anadir(Ordenador ordenador)
    {
        var ultimoNumero = _ordenadores.Count;
        ordenador.Id = ultimoNumero;
        _ordenadores.Add(ordenador);
    }

    public void Borrar(int id)
    {
        _ordenadores.RemoveAt(id);
    }

    public Ordenador Obtener(int id)
    {
        return _ordenadores.First(x => x.Id == id);
    }

    public List<Ordenador> Listar()
    {
        return _ordenadores;
    }

    public void Actualizar(int id, Ordenador ordenador)
    {
        {
            var componenteEditar = _ordenadores.First(x => x.Id == id);
            componenteEditar.Id = ordenador.Id;
            componenteEditar.Description = ordenador.Description;
            componenteEditar.Componentes = ordenador.Componentes;
        }
    }
}