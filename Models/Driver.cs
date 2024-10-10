using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class Driver
    {
        public decimal EmployeeNumber { get; set; }
        public string Identification { get; set; } = null!;
        public string? FullName { get; set; }
        public int? LicenseCategory { get; set; }
    }
}
