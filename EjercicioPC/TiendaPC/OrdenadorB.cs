using EjercicioPC.Componentes.Clases;
using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.TiendaPC
{
	public class OrdenadorB : Ordenador, IConjuntoComponentes
	{
		private readonly int calorTotal;
		private readonly double precioTotal;
		private readonly long almacenamientoTotal;

		public OrdenadorB(DiscoDuro _rom, Procesador _proc, Ram _ram, AlmacenamientoSecundario _secRom) : base(_rom, _proc, _ram)
		{
			var rom = _rom;
			var proc = _proc;
			var ram = _ram;
			var secRom = _secRom;
			calorTotal = (ram as ICalor).Calor + (rom as ICalor).Calor + (proc as ICalor).Calor + (secRom as ICalor).Calor;
			precioTotal = (ram as IPriceable).Precio + (rom as IPriceable).Precio + (proc as IPriceable).Precio + (secRom as IPriceable).Precio;
			almacenamientoTotal = (ram as IAlmacenamiento).Almacenamiento + (rom as IAlmacenamiento).Almacenamiento + (secRom as IAlmacenamiento).Almacenamiento;
		}


		public new int GetCalor()
		{
			return calorTotal;
		}

		public new double GetPrecio()
		{
			return precioTotal;
		}

		public new long GetAlmacenamiento()
		{
			return almacenamientoTotal;
		}
	}
}
