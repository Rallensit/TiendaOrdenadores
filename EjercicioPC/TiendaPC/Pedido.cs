using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.TiendaPC;

public class Pedido
{
    readonly List<IConjuntoComponentes> _pcList = new();
    private int _calorTotal;
    private double _precioTotal;
    private long _espacioTotal;

    public int CalorTotal
    {
        get => _calorTotal;
        set => _calorTotal += value;
    }

    public double PrecioTotal
    {
        get => _precioTotal;
        set => _precioTotal += value;
    }

    public long EspacioTotal
    {
        get => _espacioTotal;
        set => _espacioTotal += value;
    }

    public void Add(IConjuntoComponentes pc)
    {
        _pcList.Add(pc);
        CalorTotal = pc.GetCalor();
        PrecioTotal = pc.GetPrecio();
        EspacioTotal = pc.GetAlmacenamiento();
    }

    public int Count()
    {
        return _pcList.Count;
    }

    public void Clear()
    {
        _pcList.Clear();
    }

    public void Delete(int id)
    {
        _pcList.RemoveAt(id);
    }
}