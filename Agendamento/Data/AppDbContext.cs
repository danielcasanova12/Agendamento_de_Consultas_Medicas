using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento.Model;
using Microsoft.EntityFrameworkCore;

namespace Agendamento.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Consulta>? Consultas { get; set; }
        public DbSet<Especialidade>? Especialidades { get; set; }
        public DbSet<Medico>? Medicos { get; set; }
        public DbSet<Paciente>? Pacientes { get; set; }
        public DbSet<Recepcionista>? Recepcionistas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Tds.db;Cache=Shared");
        }
    }
}