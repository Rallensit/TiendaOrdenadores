using EjercicioPC.TiendaPC;

namespace EjercicioPC.Validators.Pc
{
	public interface IPcValidator
	{
		bool IsValid(Ordenador ordenador);
	}
}
