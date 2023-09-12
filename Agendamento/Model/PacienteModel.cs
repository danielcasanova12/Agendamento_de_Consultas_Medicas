using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Model
{
    public class Paciente
    {
        public int? IdPaciente { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NúmeroIdentificação { get; set; }
        public string? HistoricoMedico { get; set; }
        public List<Consulta>? ConsultasAgendadas { get; set; }
    }
}