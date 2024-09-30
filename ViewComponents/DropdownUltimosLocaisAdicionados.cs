using Microsoft.AspNetCore.Mvc;
using projeto_cinema.Repositorios;
using System.Threading.Tasks;

namespace projeto_cinema.ViewComponents
{
    public class DropdownUltimosLocaisAdicionados : ViewComponent
    {
        private readonly ILocaisRepositorio _locaisRepositorio;

        public DropdownUltimosLocaisAdicionados(ILocaisRepositorio locaisRepositorio)
        {
            _locaisRepositorio = locaisRepositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ultimosLocais = _locaisRepositorio.BuscarUltimos3Locais();
            return View(ultimosLocais);
        }
    }
}
