using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ViewInfoUser
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? TypeUser { get; set; }
        public string? RolUser { get; set; }
        public int? Status { get; set; }
    }
}
