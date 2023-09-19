namespace WebApiOrdenadores.Services;

public interface IRepositorioGenerico<T>
{
    List<T>? Listar();
    T? Obtener(int id);
    void Anadir(T t);
    void Actualizar(int id, T t);
    void Borrar(int id);
}