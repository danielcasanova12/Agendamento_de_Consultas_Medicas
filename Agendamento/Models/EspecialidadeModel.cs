using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Agendamento.Model
{
    public class Especialidade
    {
        [Key]
        public int? IdEspecialidade { get; set; }
        public string? Nome { get; set; }
        public string? Descrição { get; set; }
        public List<Medico>? Medicos { get; set; }

    }
}