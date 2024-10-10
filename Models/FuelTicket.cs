using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class FuelTicket
    {
        public decimal FuelTicketId { get; set; }
        public int? Amount { get; set; }
        public int? Sequential { get; set; }
        public string? BarCode { get; set; }
        public short? DeliveryMonth { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Status { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public DateTime? RegisterDate { get; set; }
    }
}
