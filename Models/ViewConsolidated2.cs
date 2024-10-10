using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ViewConsolidated2
    {
        public DateTime? CreationDate { get; set; }
        public string? Ficha { get; set; }
        public string? NameBrand { get; set; }
        public string? ModelName { get; set; }
        public int? TypeDriver { get; set; }
        public string? FullName { get; set; }
        public string? TravelReason { get; set; }
        public int? Amount { get; set; }
        public int EnGalones { get; set; }
        public int KmaRecorer { get; set; }
        public string? Period { get; set; }
    }
}
