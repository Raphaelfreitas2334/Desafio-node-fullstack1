using Microsoft.EntityFrameworkCore;
using projeto_cinema.Data;
using projeto_cinema.Models;

namespace projeto_cinema.Repositorios
{
    public class EventosRepositorio : IEventosRepositorio
    {
        //essa variavel será usada para dar acesso ao contexto do banco
        //que será utilizada para realizar as operações (CRUD)
        private readonly BancoContext _bancoContext;
        public EventosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }

        public EventosModel AdicionarEventos(EventosModel eventos)
        {
            _bancoContext.Eventos.Add(eventos);
            _bancoContext.SaveChanges();

            return eventos;
        }

        public List<EventosModel> BuscarEventos()
        {

            return _bancoContext.Eventos.ToList();
        }

        public List<EventosModel> BuscarUltimos3Eventos()
        {
            return _bancoContext.Eventos
               .OrderByDescending(l => l.Id) // Supondo que você tenha uma propriedade DataDeCadastro
               .Take(3)
               .ToList();
        }

        public EventosModel editarEventos(EventosModel eventos)
        {
            EventosModel eventosDB = listarPorID(eventos.Id);
            if (eventosDB == null) throw new System.Exception("Houve um erro na atualização do alimento");

            eventosDB.NomeDoEvento = eventos.NomeDoEvento;
            eventosDB.TipoDeEvento= eventos.TipoDeEvento;
            eventosDB.DataDoEvento = eventos.DataDoEvento;
            eventosDB.HoraDoEvento = eventos.HoraDoEvento;
            eventosDB.HoraDoFimEvento = eventos.HoraDoFimEvento;
            //eventosDB.SelecioneUmLocal = eventos.SelecioneUmLocal;
            eventosDB.Email = eventos.Email;
            eventosDB.Telefone = eventos.Telefone;

            _bancoContext.Eventos.Update(eventosDB);
            _bancoContext.SaveChanges();
            return eventosDB;
        }

        public bool excluirEventos(int id)
        {
            EventosModel eventosDB = listarPorID(id);

            if (eventosDB == null) throw new System.Exception("Houve um erro na deleçaõ do Local!");

            _bancoContext.Eventos.Remove(eventosDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public EventosModel listarPorID(int id)
        {
            return _bancoContext.Eventos.FirstOrDefault(x => x.Id == id);
        }
    }
}
