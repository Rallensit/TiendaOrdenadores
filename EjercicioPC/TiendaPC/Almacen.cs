using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.TiendaPC
{
	public class Almacen : IGuardadorComponentes
	{
		private readonly Dictionary<string, int> almacen;
		public Almacen()
		{
			almacen = new Dictionary<string, int>();
		}

		public void Add(string serie, int cantidad)
		{
			almacen.Add(serie, cantidad);
		}

		public bool Use(string serie)
		{
			if (almacen.ContainsKey(serie))
			{
				if (Check(serie))
				{
					almacen[serie] -= 1;
					return true;
				}
				return false;
			}
			return false;
		}
		public bool Check(string serie)
		{
			return almacen[serie] > 0;
		}
	}
}
