using EjercicioPC.Componentes.Interfaces;

namespace EjercicioPC.Componentes.Clases
{
	public class Ram : Componente, IAlmacenamiento
	{
		public long Almacenamiento { get; set; }

		public Ram(string _serie,int _calor, long _almacenamiento, double _precio)
		{
			Serie = _serie;
			Calor = _calor;
			Almacenamiento = _almacenamiento;
			Precio = _precio;
		}
	}
}
