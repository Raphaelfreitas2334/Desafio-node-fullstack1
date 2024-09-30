using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_cinema.Data;
using projeto_cinema.Models;
using projeto_cinema.Repositorios;

namespace projeto_cinema.Controllers
{
    public class LocaisController : Controller
    {
        private readonly ILocaisRepositorio _locaisRepositorio;
        private readonly BancoContext _bancoContext;

        public LocaisController(ILocaisRepositorio locais,
                                BancoContext bancoContext)
        {
            _locaisRepositorio = locais;
            _bancoContext = bancoContext;
        }
        // GET: LocaisController
        //tela inicial dos Locais
        public ActionResult Index()
        {
            List<LocaisModel> locais = _locaisRepositorio.BuscarLocais();
            return View(locais);
        }

        // GET: LocaisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocaisController/Create
        public ActionResult Adicionar()
        {
            return View();
        }

        // POST: LocaisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(LocaisModel locais)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            {
                try
                {
                    if (!ModelState.IsValid)
                    {
                        locais = _locaisRepositorio.AdicionarLocais(locais);
                        TempData["MensagemSucesso"] = "Local cadastrado com sucesso!";
                        transaction.Commit();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Erro na validação dos dados.";
                        return View(locais); // Retorne a mesma view com os dados preenchidos
                    }
                }
                catch (System.Exception erro)
                {
                    transaction.Rollback(); 
                    TempData["MensagemErro"] = $"Não foi possível cadastrar o local, temte novamente: {erro.Message}";
                    return View(locais); // Retorne a mesma view com os dados preenchidos
                }
            }
        }


        // GET: LocaisController/Edit/5
        public ActionResult Editar(int id)
        {
            LocaisModel locaisPorID = _locaisRepositorio.listarPorID(id);
            return View(locaisPorID);
        }

        // POST: LocaisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(LocaisModel local)
        {
            using (var transaction = _bancoContext.Database.BeginTransaction())
            try
            {

                if (!ModelState.IsValid)
                {
                    
                    _locaisRepositorio.editarLocais(local);
                    TempData["MensagemSucesso"] = "Local Alterado com sucesso";
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Erro na atualização dos dados.";
                    return View(local); // Retorne a mesma view com os dados preenchidos
                }
            }
            catch (System.Exception erro)
            {
                transaction.Rollback();
                TempData["MensagemErro"] = $"Não foi possível atualização o lodal, temte novamente: {erro.Message}";
                return View(local); // Retorne a mesma view com os dados preenchidos
            }
        }

        // GET: LocaisController/Delete/5
        public IActionResult Deletar(int Id)
        {
            LocaisModel locais = _locaisRepositorio.listarPorID(Id);
            return PartialView("_Deletar", locais);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _locaisRepositorio.excluirLocais(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario Excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops. nao consiguimos Excluir o Usuario, temte novamente";
                }


                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops. nao consiguimos Excluir o Usuario, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
