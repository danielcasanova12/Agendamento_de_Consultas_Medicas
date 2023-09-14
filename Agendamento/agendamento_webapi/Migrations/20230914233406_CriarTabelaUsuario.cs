using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_webapi.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    IdEspecialidade = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Descrição = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.IdEspecialidade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    NúmeroIdentificação = table.Column<string>(type: "TEXT", nullable: true),
                    HistoricoMedico = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "Recepcionistas",
                columns: table => new
                {
                    IdRecepcionista = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    NúmeroIdentificação = table.Column<string>(type: "TEXT", nullable: true),
                    NúmeroTelefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionistas", x => x.IdRecepcionista);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdMedico = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Especialidade = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroRegistroProfissional = table.Column<string>(type: "TEXT", nullable: true),
                    EspecialidadeIdEspecialidade = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_EspecialidadeIdEspecialidade",
                        column: x => x.EspecialidadeIdEspecialidade,
                        principalTable: "Especialidades",
                        principalColumn: "IdEspecialidade");
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MedicoIdMedico = table.Column<int>(type: "INTEGER", nullable: true),
                    PacienteIdPaciente = table.Column<int>(type: "INTEGER", nullable: true),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: true),
                    Observações = table.Column<string>(type: "TEXT", nullable: true),
                    RecepcionistaIdRecepcionista = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoIdMedico",
                        column: x => x.MedicoIdMedico,
                        principalTable: "Medicos",
                        principalColumn: "IdMedico");
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "Pacientes",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK_Consultas_Recepcionistas_RecepcionistaIdRecepcionista",
                        column: x => x.RecepcionistaIdRecepcionista,
                        principalTable: "Recepcionistas",
                        principalColumn: "IdRecepcionista");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoIdMedico",
                table: "Consultas",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteIdPaciente",
                table: "Consultas",
                column: "PacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_RecepcionistaIdRecepcionista",
                table: "Consultas",
                column: "RecepcionistaIdRecepcionista");

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_EspecialidadeIdEspecialidade",
                table: "Medicos",
                column: "EspecialidadeIdEspecialidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Recepcionistas");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
