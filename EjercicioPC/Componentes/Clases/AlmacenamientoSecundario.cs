using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.Componentes.Clases;

public class AlmacenamientoSecundario : ICalor, IPriceable, IAlmacenamiento
{
    private readonly List<DiscoDuro> _discos = new();
    public double Precio { get; set; }
    public int Calor { get; set; }
    public long Almacenamiento { get; set; }
    public readonly List<string?> Series = new();

    public void Add(DiscoDuro disco)
    {
        _discos.Add(disco);
        Series.Add(disco.Serie);
        Calor += disco.Calor;
        Precio += disco.Precio;
        Almacenamiento += disco.Almacenamiento;
    }


    public int Count()
    {
        return _discos.Count;
    }
}