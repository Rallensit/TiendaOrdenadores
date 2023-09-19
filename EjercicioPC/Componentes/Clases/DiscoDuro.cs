using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.Componentes.Clases;

public class DiscoDuro : Componente, IAlmacenamiento
{
    public long Almacenamiento { get; set; }
    public DiscoDuro(string? serie, int calor, long almacenamiento, double precio)
    {
        Serie = serie;
        Calor = calor;
        Almacenamiento = almacenamiento;
        Precio = precio;
    }
}