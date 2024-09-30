using projeto_cinema.Models;

namespace projeto_cinema.Repositorios
{
    public interface ILocaisRepositorio
    {
        LocaisModel listarPorID(int id);

        List<LocaisModel> BuscarLocais();

        List<LocaisModel> BuscarUltimos3Locais();

        LocaisModel AdicionarLocais(LocaisModel locais);

        LocaisModel editarLocais(LocaisModel locais);
        LocaisModel ObterPorI(int id);

        bool excluirLocais(int id);

        IEnumerable<LocaisModel> ObterTodos();
    }
}
