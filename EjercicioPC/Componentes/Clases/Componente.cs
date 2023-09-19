using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.Componentes.Clases;

public class Componente : ICalor, IPriceable, ISeriable
{
    public int Calor { get; set; }
    public double Precio { get; set; }
    public string? Serie { get; set; }
}