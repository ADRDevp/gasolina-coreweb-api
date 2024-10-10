using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class AssignmentFuel
    {
        public AssignmentFuel()
        {
            DeliveryTickets = new HashSet<DeliveryTicket>();
        }

        public short AssignmentFuelId { get; set; }
        public decimal EmployeeNumber { get; set; }
        public string? Identification { get; set; }
        public string? FullName { get; set; }
        public string? Positions { get; set; }
        public int? Amount { get; set; }
        public bool? Status { get; set; }
        public int? VehicleId { get; set; }
        public int? DriverType { get; set; }
        public short? DepartmentId { get; set; }

        public virtual ICollection<DeliveryTicket> DeliveryTickets { get; set; }
    }
}
