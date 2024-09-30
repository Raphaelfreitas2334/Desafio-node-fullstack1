using Microsoft.AspNetCore.Mvc;

namespace projeto_cinema.ViewComponents
{
    public class DropdownEventos : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
