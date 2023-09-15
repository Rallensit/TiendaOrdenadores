using WebApiOrdenadores.Models;

namespace EjercicioOrdenador.Services;

public interface IRepositorioComponente
{
    List<Componente>? ListaComponentes();
    Componente? GetComponente(int id);
    void AddComponente(Componente? componente);
    void Update(int id, Componente componente);
    void DeleteComponente(int id);
}