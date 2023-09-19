using EjercicioPCConsola.TiendaPC;

namespace EjercicioPCConsola.Validators.Pedidos;

public class PedidoValidator : IPedidoValidator
{
    public bool IsValid(Pedido pedido)
    {
        return pedido is { CalorTotal: >= 0, PrecioTotal: >= 0, EspacioTotal: >= 0 };
    }
}