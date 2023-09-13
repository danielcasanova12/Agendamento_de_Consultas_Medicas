using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Agendamento.Model
{
    public class Medico
    {
        [Key]
        public int? IdMedico { get; set; }
        public string? Nome { get; set; }
        public string? Especialidade { get; set; }
        public string? NúmeroRegistroProfissional { get; set; }
        public List<Consulta>? ConsultasAgendadas { get; set; }
    }
}