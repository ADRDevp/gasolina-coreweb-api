public class Fuel_FullPrice
{
    public int RegisterId { get; set; }  // Primary Key, no puede ser nulo
    public string FuelName { get; set; }  // Nombre del combustible, no nulo
    public float PriceValue { get; set; }  // Valor del precio, no nulo
    public DateTime StartDate { get; set; }  // Fecha de inicio, no nulo
    public DateTime EndDate { get; set; }  // Fecha de fin, no nulo
}
