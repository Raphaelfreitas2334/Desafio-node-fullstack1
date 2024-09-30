using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projeto_cinema.Data;
using projeto_cinema.Models;
using projeto_cinema.Repositorios;

namespace projeto_cinema.Controllers
{
    public class EventosController : Controller
    {
        private readonly IEventosRepositorio _eventosRepositorio;
        private readonly ILocaisRepositorio _locaisRepositorio;
        private readonly BancoContext _bancoContext;

        public EventosController(IEventosRepositorio eventos,
                                ILocaisRepositorio locais,
                                BancoContext bancoContext)
        {
            _eventosRepositorio = eventos;
            _bancoContext = bancoContext;
        }
        // GET: EventosController
        public ActionResult Index()
        {
            List<EventosModel> eventos = _eventosRepositorio.BuscarEventos();
            return View(eventos);
        }

        // GET: EventosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EventosController/Create
        public ActionResult Adicionar()
        {
            var locais = _bancoContext.Locais.ToList();

            if (locais == null)
            {
                throw new InvalidOperationException("O método ObterTodos retornou null.");
            }

            var localSelectList = locais.Select(l => new SelectListItem
            {
                Value = l.NomeLocal,
                Text = l.NomeLocal
            }).ToList();

            ViewBag.Locais = localSelectList;

            return View();
        }

        // POST: EventosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(EventosModel eventos)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            try
            {
                    if (!ModelState.IsValid)
                    {
                        var local = _bancoContext.Locais.FirstOrDefault(f => f.NomeLocal == eventos.SelecioneUmLocal);

                        if (local != null)
                        {
                            eventos.LocalId = local.Id;
                        }

                        eventos = _eventosRepositorio.AdicionarEventos(eventos);
                        TempData["MensagemSucesso"] = "Evento cadastrado com sucesso!";
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Erro na validação dos dados.";
                        return View(eventos); // Retorne a mesma view com os dados preenchidos
                    }
            }
            catch (System.Exception erro)
            {
                    transaction.Rollback();
                    TempData["MensagemErro"] = $"Não foi possível cadastrar o Evento, temte novamente: {erro.Message}";
                    return View(eventos); // Retorne a mesma view com os dados preenchidos
            }
        }

        // GET: EventosController/Edit/5
        public ActionResult Editar(int id)
        {
            EventosModel locaisPorID = _eventosRepositorio.listarPorID(id);
            return View(locaisPorID);
        }

        // POST: EventosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(EventosModel evento)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            try
            {
                    if (!ModelState.IsValid)
                    {
                        var local = _bancoContext.Locais.FirstOrDefault(f => f.NomeLocal == evento.SelecioneUmLocal);

                        if (local != null)
                        {
                            evento.LocalId = local.Id;
                        }
                        _eventosRepositorio.editarEventos(evento);
                        TempData["MensagemSucesso"] = "Evento Alterado com sucesso";
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Erro na atualização dos dados.";
                        return View(evento); // Retorne a mesma view com os dados preenchidos
                    }
                }
            catch (System.Exception erro)
            {
                 transaction.Rollback();
                 TempData["MensagemErro"] = $"Não foi possível atualização o lodal, temte novamente: {erro.Message}";
                 return View(evento); // Retorne a mesma view com os dados preenchidos
            }
        }

        // GET: EventosController/Delete/5
        public ActionResult Deletar(int id)
        {
            EventosModel locais = _eventosRepositorio.listarPorID(id);
            return PartialView("_Deletar", locais);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                bool apagado = _eventosRepositorio.excluirEventos(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Evento Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o Evento, temte novamente";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Evento o Usuario, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
