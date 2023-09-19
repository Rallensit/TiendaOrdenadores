using EjercicioPCConsola.Componentes.Interfaces;

namespace EjercicioPCConsola.TiendaPC;

public class Factura : IPriceable
{
    public readonly List<Pedido> Fac = new();
    public double Precio { get; set; }

    public void Add(Pedido pedido)
    {
        Fac.Add(pedido);
        Precio += pedido.PrecioTotal;
    }

}