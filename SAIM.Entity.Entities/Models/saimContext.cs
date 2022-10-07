using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SAIM.Domain.Entities.Models;

namespace SAIM.Services
{
    public partial class saimContext : DbContext
    {
        public saimContext()
        {
        }

        public saimContext(DbContextOptions<saimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; } = null!;
        public virtual DbSet<Historiasclinica> Historiasclinicas { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.Nit)
                    .HasName("PRIMARY");

                entity.ToTable("clinicas");

                entity.Property(e => e.Nit)
                    .HasMaxLength(30)
                    .HasColumnName("NIT");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(45)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Dirección).HasMaxLength(45);

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");

                entity.Property(e => e.RazonSocial)
                    .HasMaxLength(80)
                    .HasColumnName("razon_social");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Historiasclinica>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.PacientesCedula })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("historiasclinicas");

                entity.HasIndex(e => e.PacientesCedula, "fk_HistoriasClinicas_Pacientes1_idx");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PacientesCedula)
                    .HasMaxLength(15)
                    .HasColumnName("Pacientes_cedula");

                entity.Property(e => e.Anamnesis).HasMaxLength(150);

                entity.Property(e => e.AntecedentesFamiliares).HasMaxLength(150);

                entity.Property(e => e.AntecendentesPersonales).HasMaxLength(100);

                entity.Property(e => e.Autor).HasMaxLength(45);

                entity.Property(e => e.Diagnostico).HasMaxLength(150);

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Tratamiento).HasMaxLength(150);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => new { e.Cedula, e.ClinicasNit })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("pacientes");

                entity.HasIndex(e => e.ClinicasNit, "fk_Pacientes_Clinicas1_idx");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(15)
                    .HasColumnName("cedula");

                entity.Property(e => e.ClinicasNit)
                    .HasMaxLength(30)
                    .HasColumnName("Clinicas_NIT");

                entity.Property(e => e.Apellidos).HasMaxLength(30);

                entity.Property(e => e.FechaDeNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombres).HasMaxLength(30);

                entity.HasOne(d => d.ClinicasNitNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.ClinicasNit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pacientes_Clinicas1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
