﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using agendamento_webapi.Data;

#nullable disable

namespace agendamento_webapi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230921203231_v3")]
    partial class v3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("ClassModels.ConsultaModel", b =>
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

                    b.Property<int?>("RecepcionistaModelIdRecepcionista")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdConsulta");

                    b.HasIndex("MedicoIdMedico");

                    b.HasIndex("PacienteIdPaciente");

                    b.HasIndex("RecepcionistaModelIdRecepcionista");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("ClassModels.EspecialidadeModel", b =>
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

            modelBuilder.Entity("ClassModels.MedicoModel", b =>
                {
                    b.Property<int?>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Especialidade")
                        .HasColumnType("TEXT");

                    b.Property<int?>("EspecialidadeModelIdEspecialidade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroRegistroProfissional")
                        .HasColumnType("TEXT");

                    b.HasKey("IdMedico");

                    b.HasIndex("EspecialidadeModelIdEspecialidade");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("ClassModels.PacienteModel", b =>
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

            modelBuilder.Entity("ClassModels.RecepcionistaModel", b =>
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

            modelBuilder.Entity("ClassModels.ConsultaModel", b =>
                {
                    b.HasOne("ClassModels.MedicoModel", "Medico")
                        .WithMany("ConsultasAgendadas")
                        .HasForeignKey("MedicoIdMedico");

                    b.HasOne("ClassModels.PacienteModel", "Paciente")
                        .WithMany("ConsultasAgendadas")
                        .HasForeignKey("PacienteIdPaciente");

                    b.HasOne("ClassModels.RecepcionistaModel", null)
                        .WithMany("AgendamentosGerenciados")
                        .HasForeignKey("RecepcionistaModelIdRecepcionista");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("ClassModels.MedicoModel", b =>
                {
                    b.HasOne("ClassModels.EspecialidadeModel", null)
                        .WithMany("Medicos")
                        .HasForeignKey("EspecialidadeModelIdEspecialidade");
                });

            modelBuilder.Entity("ClassModels.EspecialidadeModel", b =>
                {
                    b.Navigation("Medicos");
                });

            modelBuilder.Entity("ClassModels.MedicoModel", b =>
                {
                    b.Navigation("ConsultasAgendadas");
                });

            modelBuilder.Entity("ClassModels.PacienteModel", b =>
                {
                    b.Navigation("ConsultasAgendadas");
                });

            modelBuilder.Entity("ClassModels.RecepcionistaModel", b =>
                {
                    b.Navigation("AgendamentosGerenciados");
                });
#pragma warning restore 612, 618
        }
    }
}
