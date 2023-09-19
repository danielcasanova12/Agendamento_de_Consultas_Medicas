using System.ComponentModel.DataAnnotations;

namespace Agenda_Web.Models
{
    public class Recepcionista
    {
        [Key]
        public int? IdRecepcionista { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NúmeroIdentificação { get; set; }
        public string? NúmeroTelefone { get; set; }
        public List<Consulta>? AgendamentosGerenciados { get; set; }
    }
}
