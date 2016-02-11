using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Data;

namespace Ecommerce.Data.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
       EcommerceContext Init();
    }
}
