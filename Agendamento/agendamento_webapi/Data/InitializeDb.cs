using ClassModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace agendamento_webapi.Data
{
    public  class InitializeDb
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Verifique se já existem médicos no banco de dados.
            if (!context.Medicos!.Any())
            {
                // Popule o banco de dados com alguns médicos iniciais.
                var medicos = new List<Medico>
                {
                    new Medico
                    {
                        Nome = "Dr. João",
                        Especialidade = "Cardiologia",
                        NumeroRegistroProfissional = "12345",
                        ConsultasAgendadas = new List<Consulta>()
                    },
                    new Medico
                    {
                        Nome = "Dra. Maria",
                        Especialidade = "Dermatologia",
                        NumeroRegistroProfissional = "67890",
                        ConsultasAgendadas = new List<Consulta>()
                    }
                    // Adicione mais médicos conforme necessário
                };

                context.Medicos!.AddRange(medicos);
                context.SaveChanges();
            }
        }
    }
}
