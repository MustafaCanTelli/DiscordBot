using DataAccess.Entities;
using DataAccess.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DataAccess.Context
{
    public class IceCrownDbContext : DbContext
    {
        public IceCrownDbContext()
        {
            Database.Connection.ConnectionString = "Server=.;Database=IceCrownDb;Trusted_Connection=True;";
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppUserRole> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
