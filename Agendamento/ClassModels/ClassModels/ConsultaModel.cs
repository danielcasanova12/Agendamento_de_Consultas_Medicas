﻿using System.ComponentModel.DataAnnotations;

namespace ClassModels
{
    public class ConsultaModel
    {
        [Key]
        public int? IdConsulta { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }
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