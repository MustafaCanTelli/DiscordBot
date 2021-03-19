using DataAccess.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class ProjectDbContext :DbContext
    {      
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }        

    }
}
