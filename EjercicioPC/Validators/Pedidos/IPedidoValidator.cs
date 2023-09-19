using EjercicioPCConsola.TiendaPC;

namespace EjercicioPCConsola.Validators.Pedidos;

public interface IPedidoValidator
{
	bool IsValid(Pedido pedido);
}