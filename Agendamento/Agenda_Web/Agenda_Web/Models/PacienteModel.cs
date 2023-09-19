using System.ComponentModel.DataAnnotations;

namespace Agenda_Web.Models
{

    namespace Agendamento.Model
    {
        public class PacienteModel
        {
            [Key]
            public int? IdPaciente { get; set; }
            public string? Nome { get; set; }
            public string? Sobrenome { get; set; }
            public string? NúmeroIdentificação { get; set; }
            public string? HistoricoMedico { get; set; }
            public List<ConsultaModel>? ConsultasAgendadas { get; set; }
        }
    }
}
