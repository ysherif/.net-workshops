using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Entities
{
    public class Stock:Entity
    {
        public bool Available { get; set; }
        public int Quantity { get; set; }
    }
}
