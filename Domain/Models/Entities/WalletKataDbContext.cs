using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models.Entities;

public partial class WalletKataDbContext : DbContext
{
    public WalletKataDbContext()
    {
    }

    public WalletKataDbContext(DbContextOptions<WalletKataDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Saldo> Saldos { get; set; }

    public virtual DbSet<TiposMoneda> TiposMonedas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PTUJ72T;Database=WalletKataDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Saldo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_saldos_id");

            entity.ToTable("saldos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdTipoModena).HasColumnName("id_tipo_modena");
            entity.Property(e => e.Importe).HasColumnName("importe");

            entity.HasOne(d => d.IdTipoModenaNavigation).WithMany(p => p.Saldos)
                .HasForeignKey(d => d.IdTipoModena)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tipos_Monedas_id_tipo_modena");
        });

        modelBuilder.Entity<TiposMoneda>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tipos_monedas_id");

            entity.ToTable("tipos_monedas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("activo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Modena)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("modena");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
