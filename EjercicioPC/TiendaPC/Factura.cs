using System;
using System.Collections.Generic;
using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.TiendaPC
{
	public class Factura : IPriceable
	{
		private readonly List<Pedido> factura;
		public double Precio { get; set; }

		public Factura()
		{
			factura = new List<Pedido>();
		}

		public void Add(Pedido pedido)
		{
			factura.Add(pedido);
			Precio += pedido.PrecioTotal;
		}

	}
}
