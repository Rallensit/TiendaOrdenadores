using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.TiendaPC
{
	public class Pedido
	{
		readonly List<IConjuntoComponentes> pcList = new();
		private int calorTotal;
		private double precioTotal;
		private long espacioTotal;

		public int CalorTotal
		{
			get => calorTotal;
			set => calorTotal += value;
		}

		public double PrecioTotal
		{
			get => precioTotal;
			set => precioTotal += value;
		}

		public long EspacioTotal
		{
			get => espacioTotal;
			set => espacioTotal += value;
		}

		public void Add(IConjuntoComponentes pc)
		{
			pcList.Add(pc);
			CalorTotal = pc.GetCalor();
			PrecioTotal = pc.GetPrecio();
			EspacioTotal = pc.GetAlmacenamiento();
		}

		public int Count()
		{
			return pcList.Count;
		}

		public void Clear()
		{
			pcList.Clear();
		}

		public void Delete(int id)
		{
			pcList.RemoveAt(id);
		}
	}
}
