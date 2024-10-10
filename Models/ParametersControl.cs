using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ParametersControl
    {
        public long ParametersId { get; set; }
        public string KeyWord { get; set; } = null!;
        public int CompanyCode { get; set; }
        public int Ocode { get; set; }
        public int? ModuleId { get; set; }
        public string? Ccode { get; set; }
        public int? NumericData { get; set; }
        public double? DoubleData { get; set; }
        public string? StringData { get; set; }
        public bool? BooleanData { get; set; }
        public DateTime? DateData { get; set; }
        public bool? Status { get; set; }
        public int? Cuser { get; set; }
        public DateTime? Cdate { get; set; }
        public int? Wuser { get; set; }
        public DateTime? Wdate { get; set; }
        public string? Description { get; set; }
    }
}
