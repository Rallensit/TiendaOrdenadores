using EjercicioPC.TiendaPC;

namespace EjercicioPC.Validators.Pc
{
	public class PcValidator : IPcValidator
	{
		public bool IsValid(Ordenador ordenador)
		{
			return ordenador.GetCalor() >= 0 && ordenador.GetPrecio() >= 0 && ordenador.GetAlmacenamiento() >= 0;
		}

	}
}
