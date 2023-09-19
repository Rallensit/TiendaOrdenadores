using EjercicioPCConsola.Componentes.Clases;
using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.TiendaPC;

public class Ordenador : IConjuntoComponentes
{
    private readonly int _calorTotal;
    private readonly double _precioTotal;
    private readonly long _almacenamientoTotal;

    public Ordenador(DiscoDuro rom, Procesador proc, Ram ram)
    {
        var romPc = rom;
        var procPc = proc;
        var ramPc = ram;
        _calorTotal = (ramPc as ICalor).Calor + (romPc as ICalor).Calor + (procPc as ICalor).Calor;
        _precioTotal = (ramPc as IPriceable).Precio + (romPc as IPriceable).Precio + (procPc as IPriceable).Precio;
        _almacenamientoTotal = (ramPc as IAlmacenamiento).Almacenamiento + (romPc as IAlmacenamiento).Almacenamiento;
    }

    public long GetAlmacenamiento()
    {
        return _almacenamientoTotal;
    }

    public int GetCalor()
    {
        return _calorTotal;
    }

    public double GetPrecio()
    {
        return _precioTotal;
    }

}