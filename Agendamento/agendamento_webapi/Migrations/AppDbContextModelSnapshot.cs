﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using agendamento_webapi.Data;

#nullable disable

namespace agendamento_webapi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("agendamento_webapi.Models.Agendamento.Model.PacienteModel", b =>
                {
                    b.Property<int?>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HistoricoMedico")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NúmeroIdentificação")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("IdPaciente");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Consulta", b =>
                {
                    b.Property<int?>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MedicoIdMedico")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observações")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PacienteIdPaciente")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RecepcionistaIdRecepcionista")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdConsulta");

                    b.HasIndex("MedicoIdMedico");

                    b.HasIndex("PacienteIdPaciente");

                    b.HasIndex("RecepcionistaIdRecepcionista");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Especialidade", b =>
                {
                    b.Property<int?>("IdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descrição")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("IdEspecialidade");

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Medico", b =>
                {
                    b.Property<int?>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Especialidade")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EspecialidadeIdEspecialidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroRegistroProfissional")
                        .HasColumnType("TEXT");

                    b.HasKey("IdMedico");

                    b.HasIndex("EspecialidadeIdEspecialidade");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Recepcionista", b =>
                {
                    b.Property<int?>("IdRecepcionista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NúmeroIdentificação")
                        .HasColumnType("TEXT");

                    b.Property<string>("NúmeroTelefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.HasKey("IdRecepcionista");

                    b.ToTable("Recepcionistas");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Consulta", b =>
                {
                    b.HasOne("agendamento_webapi.Models.Medico", "Medico")
                        .WithMany("ConsultasAgendadas")
                        .HasForeignKey("MedicoIdMedico");

                    b.HasOne("agendamento_webapi.Models.Agendamento.Model.PacienteModel", "Paciente")
                        .WithMany("ConsultasAgendadas")
                        .HasForeignKey("PacienteIdPaciente");

                    b.HasOne("agendamento_webapi.Models.Recepcionista", null)
                        .WithMany("AgendamentosGerenciados")
                        .HasForeignKey("RecepcionistaIdRecepcionista");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Medico", b =>
                {
                    b.HasOne("agendamento_webapi.Models.Especialidade", null)
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadeIdEspecialidade");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Agendamento.Model.PacienteModel", b =>
                {
                    b.Navigation("ConsultasAgendadas");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Especialidade", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Medico", b =>
                {
                    b.Navigation("ConsultasAgendadas");
                });

            modelBuilder.Entity("agendamento_webapi.Models.Recepcionista", b =>
                {
                    b.Navigation("AgendamentosGerenciados");
                });
#pragma warning restore 612, 618
        }
    }
}
