using Microsoft.AspNetCore.Mvc;

namespace EjercicioOrdenador.ViewComoponents;

public class ComponentsList : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }
}