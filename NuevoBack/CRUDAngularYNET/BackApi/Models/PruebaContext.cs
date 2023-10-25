using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackApi.Models;

public partial class PruebaContext : DbContext
{
    public PruebaContext()
    {
    }

    public PruebaContext(DbContextOptions<PruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__cargo__3213E83F21D2ECA6");

            entity.ToTable("cargo");

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Codigo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__3213E83F10581D95");

            entity.ToTable("departamento");

            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Codigo)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__users__3213E83F3B8EFC5C");

            entity.ToTable("users");

            entity.Property(e => e.Primerapellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Primernombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Segundoapellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Segundonombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("fk_cargo");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("fk_departamento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
