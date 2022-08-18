using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreditosMicroAgroAPI.Models
{
    public partial class CreditosMicroAgroContext : DbContext
    {
        public CreditosMicroAgroContext()
        {
        }

        public CreditosMicroAgroContext(DbContextOptions<CreditosMicroAgroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clientes { get; set; } = null!;
        public virtual DbSet<Loan> Creditos { get; set; } = null!;
        public virtual DbSet<Employee> Empleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CreditosMicroAgro;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clientes");

                entity.Property(e => e.Ciudad).HasColumnName("ciudad");

                entity.Property(e => e.Identidad).HasColumnName("identidad");

                entity.Property(e => e.Nombre).HasColumnName("nombre");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("creditos");

                entity.Property(e => e.Cliente).HasColumnName("cliente");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Monto)
                    .HasColumnType("money")
                    .HasColumnName("monto");

                entity.Property(e => e.Plazo).HasColumnName("plazo");

                entity.Property(e => e.TipoProducto).HasColumnName("tipo_producto");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.IdGuid)
                    .HasColumnName("idGUID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Identidad).HasColumnName("identidad");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
