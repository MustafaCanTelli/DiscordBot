using DAL.Models.Icc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class IccDbContext : DbContext
    {
        public IccDbContext(DbContextOptions<IccDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }
    }
}
