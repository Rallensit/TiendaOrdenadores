using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.Componentes.Clases;

public class Ram : Componente, IAlmacenamiento
{
    public long Almacenamiento { get; set; }

    public Ram(string? serie,int calor, long almacenamiento, double precio)
    {
        Serie = serie;
        Calor = calor;
        Almacenamiento = almacenamiento;
        Precio = precio;
    }
}