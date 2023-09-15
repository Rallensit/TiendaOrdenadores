using EjercicioPC.Componentes.Clases;
using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.TiendaPC
{
	public class Ordenador : IConjuntoComponentes
	{
		private readonly int calorTotal;
		private readonly double precioTotal;
		private readonly long almacenamientoTotal;

		public Ordenador(DiscoDuro _rom, Procesador _proc, Ram _ram)
		{
			var rom = _rom;
			var proc = _proc;
			var ram = _ram;
			calorTotal = (ram as ICalor).Calor + (rom as ICalor).Calor + (proc as ICalor).Calor;
			precioTotal = (ram as IPriceable).Precio + (rom as IPriceable).Precio + (proc as IPriceable).Precio;
			almacenamientoTotal = (ram as IAlmacenamiento).Almacenamiento + (rom as IAlmacenamiento).Almacenamiento;
		}

		public long GetAlmacenamiento()
		{
			return almacenamientoTotal;
		}

		public int GetCalor()
		{
			return calorTotal;
		}

		public double GetPrecio()
		{
			return precioTotal;
		}

	}
}
