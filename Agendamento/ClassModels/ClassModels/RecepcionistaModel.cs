using System.ComponentModel.DataAnnotations;

namespace ClassModels
{
    public class RecepcionistaModel
    {
        [Key]
        public int? IdRecepcionista { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NúmeroIdentificação { get; set; }
        public string? NúmeroTelefone { get; set; }
        public List<ConsultaModel>? AgendamentosGerenciados { get; set; }
    }
}
