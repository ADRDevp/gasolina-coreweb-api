using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }

        public int BrandId { get; set; }
        public string? NameBrand { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
