using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.Componentes.Clases
{
	public class Procesador : Componente, IProcesable
	{
		public int Cores { get; set; }
		public Procesador(string _serie, int _calor, int _cores, double _precio)
		{
			Serie = _serie;
			Calor = _calor;
			Cores = _cores;
			Precio = _precio;
		}
	}
}
