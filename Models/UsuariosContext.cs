using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudCoreMVC2026.Models;

public partial class UsuariosContext : DbContext
{
    public UsuariosContext(){
     

    }

    public UsuariosContext(DbContextOptions<UsuariosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__8D69B95FD7AA3C5F");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo).HasColumnName("ID_Cargo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__91136B90E3DA462B");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Correo)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("CORREO");
            entity.Property(e => e.IdCargo).HasColumnName("ID_CARGO");
            entity.Property(e => e.Nombrecompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRECOMPLETO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.HasOne(d => d.oCargo).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdCargo)
                .HasConstraintName("FK_Cargo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
