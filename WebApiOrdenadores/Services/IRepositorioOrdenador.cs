using WebApiOrdenadores.Models;

namespace EjercicioOrdenador.Services;

public interface IRepositorioOrdenador
{
    List<Ordenador>? ListaOrdenadores();
    Ordenador? GetOrdenador(int id);
    void AddOrdenador(Ordenador ordenador);
    void Update(int id, Ordenador ordenador);
    void DeleteOrdenador(int id);
}