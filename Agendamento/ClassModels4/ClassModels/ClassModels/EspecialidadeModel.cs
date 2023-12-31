﻿using System.ComponentModel.DataAnnotations;

namespace ClassModels
{
    public class EspecialidadeModel
    {
        [Key]
        public int? IdEspecialidade { get; set; }
        public string? Nome { get; set; }
        public string? Descrição { get; set; }
        public List<MedicoModel>? Medicos { get; set; }

    }
}
