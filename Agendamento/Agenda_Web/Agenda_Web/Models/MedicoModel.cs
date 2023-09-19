using System.ComponentModel.DataAnnotations;

namespace Agenda_Web.Models
{
    public class Medico
    {
        [Key]
        public int? IdMedico { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
        public string? NumeroRegistroProfissional { get; set; }
        public List<Consulta>? ConsultasAgendadas { get; set; }
    }
}
