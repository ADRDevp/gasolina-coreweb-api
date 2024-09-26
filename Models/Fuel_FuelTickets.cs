public class Fuel_FuelTickets
{
    public int FuelTicketId { get; set; }  // Primary Key, no puede ser nulo
    public int Amount { get; set; }  // Cantidad de combustible, no nulo
    public decimal Sequential { get; set; }  // Número secuencial, no nulo
    public string? BarCode { get; set; }  // El código de barras podría ser nulo si no se escanea
    public DateTime ExpiryDate { get; set; }  // Fecha de expiración, no nulo
    public DateTime DeliveryDate { get; set; }  // Fecha de entrega, no nulo
    public string? Observations { get; set; }  // Observaciones podrían ser nulas
    public DateTime RegisterDate { get; set; }  // Fecha de registro, no nulo
    public int AssignmentFuelId { get; set; }  // Clave foránea, no nulo
    public int EmployeeNumber { get; set; }  // Clave foránea, no nulo
}
