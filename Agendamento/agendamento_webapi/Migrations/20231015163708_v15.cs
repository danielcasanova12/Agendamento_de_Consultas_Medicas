using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_webapi.Migrations
{
    /// <inheritdoc />
    public partial class v15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoIdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteIdPaciente",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "PacienteIdPaciente",
                table: "Consultas",
                newName: "PacienteModelIdPaciente");

            migrationBuilder.RenameColumn(
                name: "MedicoIdMedico",
                table: "Consultas",
                newName: "MedicoModelIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteIdPaciente",
                table: "Consultas",
                newName: "IX_Consultas_PacienteModelIdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_MedicoIdMedico",
                table: "Consultas",
                newName: "IX_Consultas_MedicoModelIdMedico");

            migrationBuilder.AddColumn<int>(
                name: "IdMedico",
                table: "Consultas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Consultas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas",
                column: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas",
                column: "IdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoModelIdMedico",
                table: "Consultas",
                column: "MedicoModelIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_IdPaciente",
                table: "Consultas",
                column: "IdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteModelIdPaciente",
                table: "Consultas",
                column: "PacienteModelIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_IdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Medicos_MedicoModelIdMedico",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_IdPaciente",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Pacientes_PacienteModelIdPaciente",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdMedico",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_IdPaciente",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "IdMedico",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "PacienteModelIdPaciente",
                table: "Consultas",
                newName: "PacienteIdPaciente");

            migrationBuilder.RenameColumn(
                name: "MedicoModelIdMedico",
                table: "Consultas",
                newName: "MedicoIdMedico");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_PacienteModelIdPaciente",
                table: "Consultas",
                newName: "IX_Consultas_PacienteIdPaciente");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_MedicoModelIdMedico",
                table: "Consultas",
                newName: "IX_Consultas_MedicoIdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Medicos_MedicoIdMedico",
                table: "Consultas",
                column: "MedicoIdMedico",
                principalTable: "Medicos",
                principalColumn: "IdMedico");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Pacientes_PacienteIdPaciente",
                table: "Consultas",
                column: "PacienteIdPaciente",
                principalTable: "Pacientes",
                principalColumn: "IdPaciente");
        }
    }
}
