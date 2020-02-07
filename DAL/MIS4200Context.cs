using System;
using System.Collections.Generic;
using System.Data.Entity;
using cs330215MIS4200_1045_sp20.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace cs330215MIS4200_1045_sp20.DAL
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {
            // this method is a 'constructor' and is called when a new context is created
            //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context, cs330215MIS4200_1045_sp20.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<customer> Customers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // add this method - it will be used later
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}