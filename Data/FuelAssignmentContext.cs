using Microsoft.EntityFrameworkCore;

public class FuelAssignmentContext : DbContext
{
    public FuelAssignmentContext(DbContextOptions<FuelAssignmentContext> options) : base(options) { }

    public DbSet<AssignmentFuels> AssignmentFuels { get; set; }
    public DbSet<Fuel_FuelTickets> FuelTickets { get; set; }
    public DbSet<Fuel_Cars> Cars { get; set; }
    public DbSet<Fuel_Drivers> Drivers { get; set; }
    public DbSet<Fuel_FullPrice> FullPrices { get; set; }
    public DbSet<Core_ParametersControl> ParametersControl { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definir claves primarias para las entidades
        modelBuilder.Entity<AssignmentFuels>()
            .HasKey(f => f.AssignmentFuelId);  // Clave primaria de AssignmentFuels

        modelBuilder.Entity<Fuel_FuelTickets>()
            .HasKey(f => f.FuelTicketId);  // Clave primaria de Fuel_FuelTickets

        modelBuilder.Entity<Fuel_Cars>()
            .HasKey(f => f.VehicleId);  // Clave primaria de Fuel_Cars

        modelBuilder.Entity<Fuel_Drivers>()
            .HasKey(f => f.EmployeeNumber);  // Clave primaria de Fuel_Drivers

        modelBuilder.Entity<Fuel_FullPrice>()
            .HasKey(f => f.RegisterId);  // Clave primaria de Fuel_FullPrice

        modelBuilder.Entity<Core_ParametersControl>()
            .HasKey(p => p.ParameterId);  // Clave primaria de Core_ParametersControl

        base.OnModelCreating(modelBuilder);
    }
}
