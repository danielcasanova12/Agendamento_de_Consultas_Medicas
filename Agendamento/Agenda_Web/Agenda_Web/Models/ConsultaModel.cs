using Agenda_Web.Models.Agendamento.Model;
using System.ComponentModel.DataAnnotations;

namespace Agenda_Web.Models
{
    public class Consulta
    {
        [Key]
        public int? IdConsulta { get; set; }
        public Medico? Medico { get; set; }
        public PacienteModel? Paciente { get; set; }
        public DateTime? DataHora { get; set; }
        public TipoConsulta? Tipo { get; set; }
        public string? Observações { get; set; }
    }
    public enum TipoConsulta
    {
        Presencial,
        Online
    }
}