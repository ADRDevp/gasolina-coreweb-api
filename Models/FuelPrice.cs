using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class FuelPrice
    {
        public long RegisterId { get; set; }
        public string? FuelName { get; set; }
        public double? PriceValue { get; set; }
        public string? Type { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Cdate { get; set; }
        public int? Cuser { get; set; }
        public DateTime? Edate { get; set; }
        public int? Euser { get; set; }
    }
}
