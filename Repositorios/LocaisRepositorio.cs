using Microsoft.EntityFrameworkCore;
using projeto_cinema.Data;
using projeto_cinema.Models;

namespace projeto_cinema.Repositorios
{
    public class LocaisRepositorio : ILocaisRepositorio
    {
        //essa variavel será usada para dar acesso ao contexto do banco
        //que será utilizada para realizar as operações (CRUD)
        private readonly BancoContext _bancoContext;
        public LocaisRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }

        public LocaisModel AdicionarLocais(LocaisModel locais)
        {
            locais.Data = DateTime.Now;
            _bancoContext.Locais.Add(locais);
            _bancoContext.SaveChanges();

            return locais;
        }

        public List<LocaisModel> BuscarLocais()
        {
            return _bancoContext.Locais.ToList();
        }

        public List<LocaisModel> BuscarUltimos3Locais()
        {
            return _bancoContext.Locais
               .OrderByDescending(l => l.Id) // Supondo que você tenha uma propriedade DataDeCadastro
               .Take(3)
               .ToList();
        }

        public LocaisModel editarLocais(LocaisModel locais)
        {
            LocaisModel locaisDB = listarPorID(locais.Id);
            if (locaisDB == null) throw new System.Exception("Houve um erro na atualização do alimento");

            locaisDB.NomeLocal = locais.NomeLocal;
            locaisDB.Apelido = locais.Apelido;
            locaisDB.SelecioneTipo = locais.SelecioneTipo;
            locaisDB.CNPJ = locais.CNPJ;
            locaisDB.Cidade = locais.Cidade;
            locaisDB.Estado = locais.Estado;
            locaisDB.CEP = locais.CEP;
            locaisDB.Endereco = locais.Endereco;
            locaisDB.Complemento = locais.Complemento;
            locaisDB.Email = locais.Email;
            locaisDB.Telefone = locais.Telefone;
            locaisDB.CadatroCatracas = locais.CadatroCatracas;
            locaisDB.CadatroEntradas = locais.CadatroEntradas;
            locaisDB.Data = DateTime.Now;

            _bancoContext.Locais.Update(locaisDB);
            _bancoContext.SaveChanges();
            return locaisDB;
        }

        public bool excluirLocais(int id)
        {
            LocaisModel locaisDB = listarPorID(id);

            if (locaisDB == null) throw new System.Exception("Houve um erro na deleçaõ do Local!");

            _bancoContext.Locais.Remove(locaisDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public LocaisModel listarPorID(int id)
        {
            return _bancoContext.Locais.FirstOrDefault(x => x.Id == id);
        }

        public LocaisModel ObterPorI(int id)
        {
            // Consultar o locais pelo ID usando LINQ
            var locais = _bancoContext.Locais.FirstOrDefault(l => l.Id == id);

            return locais; // Retorna o locais encontrado ou null se não for encontrado
        }

        public IEnumerable<LocaisModel> ObterTodos()
        {
            return _bancoContext.Locais.ToList();
        }
    }
}
