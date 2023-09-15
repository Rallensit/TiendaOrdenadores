using EjercicioPC.TiendaPC;

namespace EjercicioPC.Validators.Pedidos;

public interface IPedidoValidator
{
	bool IsValid(Pedido pedido);
}