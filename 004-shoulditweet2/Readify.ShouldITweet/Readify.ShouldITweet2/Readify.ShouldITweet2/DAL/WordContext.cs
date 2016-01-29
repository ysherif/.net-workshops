using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Readify.ShouldITweet2.DAL
{
    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class WordContext : DbContext
        {

            public WordContext() : base("WordContext")
            {
            }

            public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
    
}