using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Entities;

namespace Ecommerce.Data.Configurations
{
    public class ProductConfiguration:EntityBaseConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
