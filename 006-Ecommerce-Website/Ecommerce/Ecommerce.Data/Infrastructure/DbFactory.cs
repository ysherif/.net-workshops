using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;
namespace Ecommerce.Data.Infrastructure
{
    public class DbFactory:IDbFactory
    {
        EcommerceContext dbContext;

        public void Dispose()
        {
           if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        public EcommerceContext Init()
        {
            return dbContext ?? (dbContext = new EcommerceContext());
        }
    }
}
