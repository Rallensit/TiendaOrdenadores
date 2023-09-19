using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.Componentes.Clases;

public class Procesador : Componente, IProcesable
{
    public int Cores { get; set; }
    public Procesador(string? serie, int calor, int cores, double precio)
    {
        Serie = serie;
        Calor = calor;
        Cores = cores;
        Precio = precio;
    }
}