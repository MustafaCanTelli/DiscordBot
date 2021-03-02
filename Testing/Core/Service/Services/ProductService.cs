using DataAccess.Context;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {

        private readonly DbContextOptions<ProjectDbContext> _options;

        public ProductService(DbContextOptions<ProjectDbContext> options)
        {
            _options = options;
        }

        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                using var context = new ProjectDbContext(_options);

                await context.Products.AddAsync(product);

                await context.SaveChangesAsync().ConfigureAwait(false);

                return product;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
