using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ViewDynamic
    {
        public string? Ficha { get; set; }
        public string? Vehicle { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public string? FullName { get; set; }
        public int? SubTotal { get; set; }
    }
}
