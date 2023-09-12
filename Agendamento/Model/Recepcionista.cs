using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agendamento.Model
{
    public class Recepcionista
    {
        public int? IdRecepcionista { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? NúmeroIdentificação { get; set; }
        public string? NúmeroTelefone { get; set; }
        public List<Consulta>? AgendamentosGerenciados { get; set; }
        }
}