using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Properties.model
{
    public class Store
    {
        public int id { get; set; }
        public int producttId { get; set; }
        public int producttQuantity { get; set; }
        
        public ICollection<Product> products { get; set; }
    }
}
