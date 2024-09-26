public class Fuel_Cars
{
    public int VehicleId { get; set; }  // Primary Key, no puede ser nulo
    public string? Ficha { get; set; }  // Podría ser nulo
    public string? Model { get; set; }  // Modelo del vehículo, podría ser nulo
    public int Year { get; set; }  // Año del vehículo, no nulo
    public string? VehiclePlate { get; set; }  // Matrícula, podría ser nulo
    public string? Chassis { get; set; }  // Chasis, podría ser nulo
}
