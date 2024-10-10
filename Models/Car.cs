using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class Car
    {
        public Car()
        {
            DeliveryTickets = new HashSet<DeliveryTicket>();
        }

        public int VehiclesId { get; set; }
        public string? Ficha { get; set; }
        public int? Model { get; set; }
        public decimal? Year { get; set; }
        public string? VehiclePlate { get; set; }
        public string? Chassis { get; set; }

        public virtual Model? ModelNavigation { get; set; }
        public virtual ICollection<DeliveryTicket> DeliveryTickets { get; set; }
    }
}
