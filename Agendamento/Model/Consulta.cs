using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Model
{
    public class Consulta
    {
        public int? IdConsulta { get; set; }
        public Medico? Medico { get; set; }
        public Paciente? Paciente { get; set; }
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