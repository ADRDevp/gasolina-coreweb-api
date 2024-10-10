using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class Model
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public int ModelId { get; set; }
        public int? BrandId { get; set; }
        public string? ModelName { get; set; }
        public bool? Status { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
