using System;
using System.ComponentModel.DataAnnotations;

namespace projeto_cinema.Models
{
    public class EventosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do evento é obrigatório.")]
        public string NomeDoEvento { get; set; }

        [Required(ErrorMessage = "O tipo de evento é obrigatório.")]
        public string TipoDeEvento { get; set; }
        public string SelecioneUmLocal { get; set; }

        [Required(ErrorMessage = "A data do evento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateOnly DataDoEvento { get; set; }

        [Required(ErrorMessage = "O horário do evento é obrigatório.")]
        [DataType(DataType.Time)]
        public TimeOnly HoraDoEvento { get; set; }

        [Required(ErrorMessage = "O horário do evento é obrigatório.")]
        [DataType(DataType.Time)]
        public TimeOnly HoraDoFimEvento { get; set; }

        public int LocalId { get; set; } // Chave estrangeira

        public LocaisModel Local { get; set; } // Navegação

        public string Email { get; set; }
        public string? Telefone { get; set; }

        public string? PortoesCadastrados { get; set; }
    }
}
