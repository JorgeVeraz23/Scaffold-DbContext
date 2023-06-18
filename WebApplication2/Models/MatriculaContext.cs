using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class MatriculaContext : DbContext
{
    public MatriculaContext()
    {
    }

    public MatriculaContext(DbContextOptions<MatriculaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__curso__5D3F75023CEA189D");

            entity.ToTable("curso");

            entity.Property(e => e.IdCurso).HasColumnName("id_curso");
            entity.Property(e => e.IdMateria).HasColumnName("id_materia");
            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");

            entity.HasOne(d => d.IdMateriaNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdMateria)
                .HasConstraintName("FK__curso__id_materi__3B75D760");

            entity.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("FK__curso__id_profes__3A81B327");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__materia__7E03FD391C186AA7");

            entity.ToTable("materia");

            entity.Property(e => e.IdMateria).HasColumnName("id_materia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("PK__persona__228148B007F965C0");

            entity.ToTable("persona");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PK__profesor__159ED617A920F0B1");

            entity.ToTable("profesor");

            entity.Property(e => e.IdProfesor).HasColumnName("id_profesor");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Profesors)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("FK__profesor__id_per__37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
