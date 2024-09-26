public class AssignmentFuels
{
    public int AssignmentFuelId { get; set; }  // Primary Key, no puede ser nulo
    public int EmployeeNumber { get; set; }  // Clave foránea de empleado, no debería ser nulo
    public int VehicleId { get; set; }  // Clave foránea de vehículo, no debería ser nulo
    public int Amount { get; set; }  // Cantidad de combustible, no nulo
    public int DriverType { get; set; }  // Tipo de conductor, no nulo
}
