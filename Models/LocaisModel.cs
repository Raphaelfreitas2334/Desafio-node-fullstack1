using System;
using System.Collections.Generic;

namespace projeto_cinema.Models
{
    public class LocaisModel
    {
        public int Id { get; set; }
        // Informações básicas
        public string NomeLocal { get; set; }
        public string? Apelido { get; set; }
        public string SelecioneTipo { get; set; }
        public string? CNPJ { get; set; }
        // Localização
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string? Complemento { get; set; }
        // Contato
        public string Email { get; set; }
        public string? Telefone { get; set; }
        // Entrada e catracas
        public string? CadatroEntradas { get; set; }
        public string? CadatroCatracas { get; set; }

        public DateTime Data { get; set; }

        // Relacionamento
        public ICollection<EventosModel> Eventos { get; set; }
    }
}
