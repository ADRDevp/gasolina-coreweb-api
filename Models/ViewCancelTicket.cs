using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ViewCancelTicket
    {
        public decimal DeliveryId { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public string? FullName { get; set; }
        public DateTime? TravelDate { get; set; }
        public int? Amount { get; set; }
        public string? TravelReason { get; set; }
        public int? VehiclesId { get; set; }
        public string? Ficha { get; set; }
        public int? Model { get; set; }
        public string? VehiclePlate { get; set; }
        public string? Chassis { get; set; }
        public bool? Status { get; set; }
    }
}
