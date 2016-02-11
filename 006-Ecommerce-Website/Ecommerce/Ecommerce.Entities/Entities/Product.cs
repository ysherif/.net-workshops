using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Product:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Category Category { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
