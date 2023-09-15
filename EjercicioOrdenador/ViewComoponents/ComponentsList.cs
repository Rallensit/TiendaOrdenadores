using EjercicioOrdenador.Models;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioOrdenador.ViewComoponents
{
    public class ComponentsList : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
