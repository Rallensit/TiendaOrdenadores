using EjercicioOrdenador.Models;

namespace EjercicioOrdenador.Services;

public interface IRepositorioOrdenador
{
    void AddOrdenador(Ordenador ordenador);
    List<Ordenador>? ListaOrdenadores();
    void DeleteOrdenador(int id);
    Ordenador? GetOrdenador(int id);
    void Update(int id, Ordenador ordenador);
}