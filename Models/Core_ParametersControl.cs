public class Core_ParametersControl
{
    public long ParameterId { get; set; }  // Primary Key, no puede ser nulo
    public string KeyWord { get; set; }  // Palabra clave, no nulo
    public int? ValueNumber { get; set; }  // Valor numérico, podría ser nulo
    public string? ValueText { get; set; }  // Texto opcional, podría ser nulo
    public string Module { get; set; }  // Módulo, no nulo
}
