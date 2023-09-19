using ClassModels;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Consulta>? Consultas { get; set; }
        public DbSet<Especialidade>? Especialidades { get; set; }
        public DbSet<Medico>? Medicos { get; set; }
        public DbSet<PacienteModel>? Pacientes { get; set; }
        public DbSet<Recepcionista>? Recepcionistas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Tds.db;Cache=Shared");
        }
    }
}
