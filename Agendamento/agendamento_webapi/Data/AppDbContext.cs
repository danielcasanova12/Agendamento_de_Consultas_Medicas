using ClassModels;
using Microsoft.EntityFrameworkCore;

namespace agendamento_webapi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ConsultaModel> Consultas { get; set; }
        public DbSet<EspecialidadeModel> Especialidades { get; set; }
        public DbSet<MedicoModel> Medicos { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<RecepcionistaModel> Recepcionistas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico) // Define a relação com o médico
                .WithMany() // Um médico pode ter muitas consultas
                .HasForeignKey(c => c.IdMedico); // Chave estrangeira para o médico

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente) // Define a relação com o paciente
                .WithMany() // Um paciente pode ter muitas consultas
                .HasForeignKey(c => c.IdPaciente); // Chave estrangeira para o paciente
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=Tds.db;Cache=Shared");
        }
    }
}
