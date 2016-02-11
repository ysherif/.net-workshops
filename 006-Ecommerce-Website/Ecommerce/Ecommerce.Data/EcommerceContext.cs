using Ecommerce.Data.Configurations;
using Ecommerce.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ecommerce.Data
{
    public class EcommerceContext:DbContext
    {

        public EcommerceContext():base("Ecommerce")
        {
            Database.SetInitializer<EcommerceContext>(null);
        }

        IDbSet<Product> Product { get; set; }
        IDbSet<Category> Category { get; set; }
        IDbSet<Stock> Stock { get; set; }
       
        public virtual void Commit()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
        
        }
    }
}
