using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Entities;
using Ecommerce.Data.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Ecommerce.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : Entity
    {
        private EcommerceContext dbContext;
        protected IDbFactory Dbfactory
        {
            get;
            private set;
        }
        protected EntityBaseRepository(IDbFactory dbFactory)
        {
            Dbfactory = Dbfactory;
        }
        protected EcommerceContext DbContext
        {
            get { return dbContext ?? (dbContext = Dbfactory.Init()); }
        }
        public IQueryable<T> All
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        public void Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = DbContext.Set<T>();
            foreach (var include in includeProperties)
            {
                query = query.Include(include);
            }
            return query;
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public T GetSingle(int Id)
        {
            return DbContext.Set<T>().First(s => s.Id == Id);
        }
    }
}
