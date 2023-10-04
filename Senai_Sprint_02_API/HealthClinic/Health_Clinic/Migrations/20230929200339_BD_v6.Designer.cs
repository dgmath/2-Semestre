﻿// <auto-generated />
using System;
using Health_Clinic.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Health_Clinic.Migrations
{
    [DbContext(typeof(HealthClinicContext))]
    [Migration("20230929200339_BD_v6")]
    partial class BD_v6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Health_Clinic.Domains.Clinica", b =>
                {
                    b.Property<Guid>("IdClinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<TimeSpan>("HorarioAbertura")
                        .HasColumnType("TIME");

                    b.Property<TimeSpan>("HorarioFechamento")
                        .HasColumnType("TIME");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdClinica");

                    b.ToTable("Clinica");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Consulta", b =>
                {
                    b.Property<Guid>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("IdMedico")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaciente")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSituacao")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Prontuario")
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdConsulta");

                    b.HasIndex("IdMedico");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdSituacao");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Especialidade", b =>
                {
                    b.Property<Guid>("IdEspecialidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdEspecialidade");

                    b.ToTable("Especialidade");
                });

            modelBuilder.Entity("Health_Clinic.Domains.FeedBack", b =>
                {
                    b.Property<Guid>("IdFeedBack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdConsulta")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IdFeedBack");

                    b.HasIndex("IdConsulta");

                    b.ToTable("FeedBack");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Medico", b =>
                {
                    b.Property<Guid>("IdMedico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("CHAR(8)");

                    b.Property<Guid>("IdClinica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEspecialidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdMedico");

                    b.HasIndex("IdClinica");

                    b.HasIndex("IdEspecialidade");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Paciente", b =>
                {
                    b.Property<Guid>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Telefone")
                        .HasColumnType("INT");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Situacao", b =>
                {
                    b.Property<Guid>("IdSituacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdSituacao");

                    b.ToTable("Situacao");
                });

            modelBuilder.Entity("Health_Clinic.Domains.TipoUsuario", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TipoUsuario");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("CHAR(60)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Consulta", b =>
                {
                    b.HasOne("Health_Clinic.Domains.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("IdMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Health_Clinic.Domains.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Health_Clinic.Domains.Situacao", "Situacao")
                        .WithMany()
                        .HasForeignKey("IdSituacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("Health_Clinic.Domains.FeedBack", b =>
                {
                    b.HasOne("Health_Clinic.Domains.Consulta", "Consulta")
                        .WithMany()
                        .HasForeignKey("IdConsulta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consulta");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Medico", b =>
                {
                    b.HasOne("Health_Clinic.Domains.Clinica", "Clinica")
                        .WithMany()
                        .HasForeignKey("IdClinica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Health_Clinic.Domains.Especialidade", "Especialidade")
                        .WithMany()
                        .HasForeignKey("IdEspecialidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Health_Clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinica");

                    b.Navigation("Especialidade");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Paciente", b =>
                {
                    b.HasOne("Health_Clinic.Domains.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Health_Clinic.Domains.Usuario", b =>
                {
                    b.HasOne("Health_Clinic.Domains.TipoUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
