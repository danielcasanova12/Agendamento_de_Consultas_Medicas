using System.ComponentModel.DataAnnotations;

namespace agendamento_webapi.Models
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
