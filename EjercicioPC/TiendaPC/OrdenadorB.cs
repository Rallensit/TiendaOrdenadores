using EjercicioPCConsola.Componentes.Clases;
using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.TiendaPC;

public class OrdenadorB : Ordenador, IConjuntoComponentes
{
    private readonly int _calorTotal;
    private readonly double _precioTotal;
    private readonly long _almacenamientoTotal;

    public OrdenadorB(DiscoDuro rom, Procesador proc, Ram ram, AlmacenamientoSecundario secRom) : base(rom, proc, ram)
    {
        var romPc = rom;
        var procPc = proc;
        var ramPc = ram;
        var secRomPc = secRom;
        _calorTotal = (ramPc as ICalor).Calor + (romPc as ICalor).Calor + (procPc as ICalor).Calor + (secRomPc as ICalor).Calor;
        _precioTotal = (ramPc as IPriceable).Precio + (romPc as IPriceable).Precio + (procPc as IPriceable).Precio + (secRomPc as IPriceable).Precio;
        _almacenamientoTotal = (ramPc as IAlmacenamiento).Almacenamiento + (romPc as IAlmacenamiento).Almacenamiento + (secRomPc as IAlmacenamiento).Almacenamiento;
    }


    public new int GetCalor()
    {
        return _calorTotal;
    }

    public new double GetPrecio()
    {
        return _precioTotal;
    }

    public new long GetAlmacenamiento()
    {
        return _almacenamientoTotal;
    }
}