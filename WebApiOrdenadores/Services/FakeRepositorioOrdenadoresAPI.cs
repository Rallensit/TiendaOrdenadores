using WebApiOrdenadores.Models;

namespace WebApiOrdenadores.Services;

public class FakeRepositorioOrdenadoresApi : IRepositorioGenerico<Ordenador>
{
    private readonly List<Ordenador> _ordenadores = new();

    public FakeRepositorioOrdenadoresApi()
    {
        _ordenadores.Add(new Ordenador() { Id = 0, Description = "Ordenador0" });
        _ordenadores.Add(new Ordenador() { Id = 1, Description = "Ordenador1" });
    }
    public List<Ordenador> Listar()
    {
        return _ordenadores;
    }
    public Ordenador Obtener(int id)
    {
        return _ordenadores.First(x => x.Id == id);
    }

    public void Anadir(Ordenador ordenador)
    {
        var ultimoNumero = _ordenadores.Count;
        ordenador.Id = ultimoNumero;
        _ordenadores.Add(ordenador);
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

    public void Borrar(int id)
    {
        _ordenadores.RemoveAt(id);
    }
}