using projeto_cinema.Models;

namespace projeto_cinema.Repositorios
{
    public interface IEventosRepositorio
    {
        EventosModel listarPorID(int id);


        List<EventosModel> BuscarEventos();

        List<EventosModel> BuscarUltimos3Eventos();

        EventosModel AdicionarEventos(EventosModel eventos);

        EventosModel editarEventos(EventosModel eventos);

        bool excluirEventos(int id);
    }
}
