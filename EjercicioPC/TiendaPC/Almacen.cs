using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.TiendaPC;

public class Almacen : IGuardadorComponentes
{
    private readonly Dictionary<string, int> _almacen = new();

    public void Add(string serie, int cantidad)
    {
        _almacen.Add(serie, cantidad);
    }

    public bool Use(string serie)
    {
        if (_almacen.ContainsKey(serie))
        {
            if (Check(serie))
            {
                _almacen[serie] -= 1;
                return true;
            }
            return false;
        }
        return false;
    }
    public bool Check(string serie)
    {
        return _almacen[serie] > 0;
    }
}