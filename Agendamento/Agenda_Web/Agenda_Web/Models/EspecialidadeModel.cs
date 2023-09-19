using System.ComponentModel.DataAnnotations;

namespace Agenda_Web.Models
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
