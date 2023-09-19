﻿using Agenda_Web.Models.Agendamento.Model;
using System.ComponentModel.DataAnnotations;

namespace Agenda_Web.Models
{
    public class ConsultaModel
    {
        [Key]
        public int? IdConsulta { get; set; }
        public MedicoModel? Medico { get; set; }
        public PacienteModel? Paciente { get; set; }
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