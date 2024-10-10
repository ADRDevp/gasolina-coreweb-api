using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class DetailTicket
    {
        public decimal DetailId { get; set; }
        public decimal? DeliveryTicketId { get; set; }
        public decimal? FuelTicketId { get; set; }

        public virtual DeliveryTicket? DeliveryTicket { get; set; }
        public virtual FuelTicket? FuelTicket { get; set; }
    }
}
