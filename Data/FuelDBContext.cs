using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using gasolina_asp.net_core_web_api.Models;

namespace gasolina_asp.net_core_web_api.Data
{
    public partial class FuelDBContext : DbContext
    {
        public FuelDBContext()
        {
        }

        public FuelDBContext(DbContextOptions<FuelDBContext> options)
            : base(options)
        {
        }

        // DbSets para las tablas de la base de datos
        public virtual DbSet<AssignmentFuel> AssignmentFuels { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<DeliveryTicket> DeliveryTickets { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DetailTicket> DetailTickets { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<FuelPrice> FuelPrices { get; set; } = null!;
        public virtual DbSet<FuelTicket> FuelTickets { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;
        public virtual DbSet<ParametersControl> ParametersControls { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ViewAssingmentTicket> ViewAssingmentTickets { get; set; } = null!;
        public virtual DbSet<ViewCancelTicket> ViewCancelTickets { get; set; } = null!;
        public virtual DbSet<ViewConsolidated> ViewConsolidateds { get; set; } = null!;
        public virtual DbSet<ViewConsolidated2> ViewConsolidated2s { get; set; } = null!;
        public virtual DbSet<ViewDelivery> ViewDeliveries { get; set; } = null!;
        public virtual DbSet<ViewDynamic> ViewDynamics { get; set; } = null!;
        public virtual DbSet<ViewFuelTicket> ViewFuelTickets { get; set; } = null!;
        public virtual DbSet<ViewInfoUser> ViewInfoUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=FuelDB;User Id=sa;Password=SSrm2823;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de AssignmentFuel
            modelBuilder.Entity<AssignmentFuel>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber)
                    .HasName("PK_AssignmentFuel_1");

                entity.ToTable("AssignmentFuel", "Fuel");

                entity.Property(e => e.EmployeeNumber).HasColumnType("numeric(10, 0)");
                entity.Property(e => e.AssignmentFuelId).ValueGeneratedOnAdd();
                entity.Property(e => e.FullName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.Identification).HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.Positions).HasMaxLength(60).IsUnicode(false);
            });

            // Configuración de otras tablas

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands", "Fuel");
                entity.Property(e => e.NameBrand).HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.VehiclesId);
                entity.ToTable("Cars", "Fuel");
                entity.Property(e => e.Chassis).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Ficha).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.VehiclePlate).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Year).HasColumnType("numeric(4, 0)");

                entity.HasOne(d => d.ModelNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Model)
                    .HasConstraintName("FK_Cars_Models");
            });

            modelBuilder.Entity<DetailTicket>(entity =>
            {
                entity.HasKey(e => e.DetailId);
                entity.ToTable("DetailTicket", "Fuel");
                entity.Property(e => e.DetailId).HasColumnType("numeric(20, 0)").ValueGeneratedOnAdd();
                entity.Property(e => e.DeliveryTicketId).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.FuelTicketId).HasColumnType("numeric(20, 0)");

                entity.HasOne(d => d.DeliveryTicket)
                    .WithMany()
                    .HasForeignKey(d => d.DeliveryTicketId)
                    .HasConstraintName("FK_DetailTicket_DeliveryTicket");

                entity.HasOne(d => d.FuelTicket)
                    .WithMany()
                    .HasForeignKey(d => d.FuelTicketId)
                    .HasConstraintName("FK_DetailTicket_FuelTickets");
            });

            // Configuración de DeliveryTicket
            modelBuilder.Entity<DeliveryTicket>(entity =>
            {
                entity.HasKey(e => e.DeliveryId);  // Definir la clave primaria
                entity.ToTable("DeliveryTicket", "Fuel");

                entity.Property(e => e.DeliveryId).HasColumnType("numeric(18, 0)");
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
                entity.Property(e => e.EmployeeNumber).HasColumnType("numeric(10, 0)");
                entity.Property(e => e.Period).HasMaxLength(7).IsUnicode(false);
                entity.Property(e => e.TravelDate).HasColumnType("datetime");
                entity.Property(e => e.TravelReason).HasMaxLength(250).IsUnicode(false);

                entity.HasOne(d => d.EmployeeNumberNavigation)
                    .WithMany(p => p.DeliveryTickets)
                    .HasForeignKey(d => d.EmployeeNumber)
                    .HasConstraintName("FK_DeliveryTicket_AssignmentFuel");

                entity.HasOne(d => d.Vehicles)
                    .WithMany(p => p.DeliveryTickets)
                    .HasForeignKey(d => d.VehiclesId)
                    .HasConstraintName("FK_DeliveryTicket_Cars");
            });

            // Configuración de FuelPrice
            modelBuilder.Entity<FuelPrice>(entity =>
            {
                entity.HasKey(e => e.RegisterId); // Definir la clave primaria
                entity.ToTable("FuelPrice", "Fuel");

                entity.Property(e => e.RegisterId).ValueGeneratedNever();
                entity.Property(e => e.FuelName).HasMaxLength(40).IsUnicode(false);
                entity.Property(e => e.Type).HasMaxLength(30).IsUnicode(false);
            });

            // Configuración de ParametersControl
            modelBuilder.Entity<ParametersControl>(entity =>
            {
                entity.HasNoKey(); // Sin clave primaria
                entity.ToTable("ParametersControl", "Core");

                entity.Property(e => e.Ccode)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("CCode");
            });

            // Configuración de Driver
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber); // Clave primaria definida
                entity.ToTable("Drivers", "Fuel");
            });

            // Configuración de ViewAssingmentTicket (Sin clave)
            modelBuilder.Entity<ViewAssingmentTicket>(entity =>
            {
                entity.HasNoKey();  // Indica que esta entidad no tiene clave
                entity.ToView("View_AssingmentTicket", "Fuel");
                entity.Property(e => e.BarCode).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreationDate).HasColumnType("datetime");
            });

            // Configuración de otras vistas sin clave
            modelBuilder.Entity<ViewCancelTicket>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("View_CancelTicket", "Fuel");
            });

            modelBuilder.Entity<ViewConsolidated>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("View_Consolidated", "Fuel");
            });

            modelBuilder.Entity<ViewConsolidated2>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("view_Consolidated2", "Fuel");
            });

            modelBuilder.Entity<ViewDelivery>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("View_Delivery", "Fuel");
            });

            modelBuilder.Entity<ViewDynamic>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("View_Dynamics", "Fuel");
            });

            modelBuilder.Entity<ViewFuelTicket>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("View_FuelTicket", "Fuel");
            });

            modelBuilder.Entity<ViewInfoUser>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("View_InfoUser", "Core");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
