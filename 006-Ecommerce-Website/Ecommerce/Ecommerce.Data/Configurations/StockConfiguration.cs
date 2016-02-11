using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Entities;
namespace Ecommerce.Data.Configurations
{
   public class StockConfiguration:EntityBaseConfiguration<Stock>
    {
        public StockConfiguration()
        {
            Property(s => s.Available).IsRequired();
        }
    }
}
