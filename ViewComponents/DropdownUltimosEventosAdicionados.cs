using Microsoft.AspNetCore.Mvc;
using projeto_cinema.Repositorios;

namespace projeto_cinema.ViewComponents
{
    public class DropdownUltimosEventosAdicionados : ViewComponent
    {
        private readonly IEventosRepositorio _eventosRepositorio;

        public DropdownUltimosEventosAdicionados(IEventosRepositorio eventosRepositorio)
        {
            _eventosRepositorio = eventosRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ultimosEventos = _eventosRepositorio.BuscarUltimos3Eventos();
            return View(ultimosEventos);
        }
    }
}
