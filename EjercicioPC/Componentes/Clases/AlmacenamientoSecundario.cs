using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.Componentes.Clases
{
	public class AlmacenamientoSecundario : ICalor, IPriceable, IAlmacenamiento
	{
		private readonly List<DiscoDuro> discos;
		public double Precio { get; set; }
		public int Calor { get; set; }
		public long Almacenamiento { get; set; }
		public readonly List<string> Series;
		public AlmacenamientoSecundario()
		{
			discos = new List<DiscoDuro>();
			Series = new List<string>();
		}
		public void Add(DiscoDuro disco)
		{
			discos.Add(disco);
			Series.Add(disco.Serie);
			Calor += disco.Calor;
			Precio += disco.Precio;
			Almacenamiento += disco.Almacenamiento;
		}


		public int Count()
		{
			return discos.Count;
		}
	}
}