using System.ComponentModel.DataAnnotations;

namespace ClassModels
{
        public class PacienteModel
        {
            [Key]
            public int? IdPaciente { get; set; }
            public string? Nome { get; set; }
            public string? Sobrenome { get; set; }
            public string? NúmeroIdentificação { get; set; }
            public string? HistoricoMedico { get; set; }
            public List<Consulta>? ConsultasAgendadas { get; set; }
        }
    
}
