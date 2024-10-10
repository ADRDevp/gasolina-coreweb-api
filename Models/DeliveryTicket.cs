using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class DeliveryTicket
    {
        public decimal DeliveryId { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public int? VehiclesId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? TravelDate { get; set; }
        public int? Amount { get; set; }
        public string? TravelReason { get; set; }
        public bool? Status { get; set; }
        public short? AssignmentFuelId { get; set; }
        public string? Period { get; set; }
        public int? TypeDriver { get; set; }

        public virtual AssignmentFuel? EmployeeNumberNavigation { get; set; }
        public virtual Car? Vehicles { get; set; }
    }
}
