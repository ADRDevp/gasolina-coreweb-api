using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ViewFuelTicket
    {
        public decimal FuelTicketId { get; set; }
        public int? Amount { get; set; }
        public int? Sequential { get; set; }
        public string? BarCode { get; set; }
        public DateTime? RegisterDate { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public string? FullName { get; set; }
        public string Estatus { get; set; } = null!;
        public short? Period { get; set; }
        public decimal? DeliveryTicketId { get; set; }
    }
}
