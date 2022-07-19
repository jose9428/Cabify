using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Models
{
    public partial class bdCabifyContext : DbContext
    {
        public bdCabifyContext()
        {
        }

        public bdCabifyContext(DbContextOptions<bdCabifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DetallePago> DetallePagos { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Tarjetum> Tarjeta { get; set; } = null!;
        public virtual DbSet<TipoPago> TipoPagos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source=(local); Initial Catalog=bdCabify;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetallePago>(entity =>
            {
                entity.HasKey(e => e.IdDetPago)
                    .HasName("PK__DetalleP__8DF84E3E75C7953C");

                entity.ToTable("DetallePago");

                entity.Property(e => e.NomChofer)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPagoNavigation)
                    .WithMany(p => p.DetallePagos)
                    .HasForeignKey(d => d.IdPago)
                    .HasConstraintName("FK__DetallePa__IdPag__300424B4");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pago__FC851A3A1CB009F4");

                entity.ToTable("Pago");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.IdTarjetaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdTarjeta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__IdTarjeta__2B3F6F97");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdTipoPago)
                    .HasConstraintName("FK__Pago__IdTipoPago__2C3393D0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pago__IdUsuario__2D27B809");
            });

            modelBuilder.Entity<Tarjetum>(entity =>
            {
                entity.HasKey(e => e.IdTarjeta)
                    .HasName("PK__Tarjeta__6AF43C157A8BA167");

                entity.Property(e => e.Cvv).HasColumnName("CVV");

                entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");

                entity.Property(e => e.NumeroTarjeta)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tarjeta)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tarjeta__IdUsuar__286302EC");
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.IdTipoPago)
                    .HasName("PK__TipoPago__EB0AA9E7AB5BC3F1");

                entity.ToTable("TipoPago");

                entity.Property(e => e.NomTipo)
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97483E35E9");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasennia)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
