using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private EcommerceContext dbContext;
        private readonly IDbFactory dbFactory;


        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public EcommerceContext DbContext
        {
           get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
