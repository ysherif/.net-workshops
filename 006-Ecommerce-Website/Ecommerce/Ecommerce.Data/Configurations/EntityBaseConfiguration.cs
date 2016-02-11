using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Entities;

namespace Ecommerce.Data.Configurations
{
    public class EntityBaseConfiguration<T>:EntityTypeConfiguration<T> where T :Entity
    {
        public EntityBaseConfiguration()
        {
            HasKey(e => e.Id);
        }
    }
}
