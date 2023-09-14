using System.ComponentModel.DataAnnotations;

namespace agendamento_webapi.Models
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
