using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agendamento_webapi.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Recepcionistas_RecepcionistaIdRecepcionista",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeIdEspecialidade",
                table: "Medicos");

            migrationBuilder.RenameColumn(
                name: "EspecialidadeIdEspecialidade",
                table: "Medicos",
                newName: "EspecialidadeModelIdEspecialidade");

            migrationBuilder.RenameIndex(
                name: "IX_Medicos_EspecialidadeIdEspecialidade",
                table: "Medicos",
                newName: "IX_Medicos_EspecialidadeModelIdEspecialidade");

            migrationBuilder.RenameColumn(
                name: "RecepcionistaIdRecepcionista",
                table: "Consultas",
                newName: "RecepcionistaModelIdRecepcionista");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_RecepcionistaIdRecepcionista",
                table: "Consultas",
                newName: "IX_Consultas_RecepcionistaModelIdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Recepcionistas_RecepcionistaModelIdRecepcionista",
                table: "Consultas",
                column: "RecepcionistaModelIdRecepcionista",
                principalTable: "Recepcionistas",
                principalColumn: "IdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeModelIdEspecialidade",
                table: "Medicos",
                column: "EspecialidadeModelIdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Recepcionistas_RecepcionistaModelIdRecepcionista",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeModelIdEspecialidade",
                table: "Medicos");

            migrationBuilder.RenameColumn(
                name: "EspecialidadeModelIdEspecialidade",
                table: "Medicos",
                newName: "EspecialidadeIdEspecialidade");

            migrationBuilder.RenameIndex(
                name: "IX_Medicos_EspecialidadeModelIdEspecialidade",
                table: "Medicos",
                newName: "IX_Medicos_EspecialidadeIdEspecialidade");

            migrationBuilder.RenameColumn(
                name: "RecepcionistaModelIdRecepcionista",
                table: "Consultas",
                newName: "RecepcionistaIdRecepcionista");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_RecepcionistaModelIdRecepcionista",
                table: "Consultas",
                newName: "IX_Consultas_RecepcionistaIdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Recepcionistas_RecepcionistaIdRecepcionista",
                table: "Consultas",
                column: "RecepcionistaIdRecepcionista",
                principalTable: "Recepcionistas",
                principalColumn: "IdRecepcionista");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Especialidades_EspecialidadeIdEspecialidade",
                table: "Medicos",
                column: "EspecialidadeIdEspecialidade",
                principalTable: "Especialidades",
                principalColumn: "IdEspecialidade");
        }
    }
}
