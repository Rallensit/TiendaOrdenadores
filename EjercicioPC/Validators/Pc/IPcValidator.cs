using EjercicioPCConsola.TiendaPC;

namespace EjercicioPCConsola.Validators.Pc;

public interface IPcValidator
{
    bool IsValid(Ordenador ordenador);
}