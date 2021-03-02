using DataAccess.Context;
using DataAccess.Model;
using DSharpPlus.CommandsNext;
using Microsoft.EntityFrameworkCore;
using Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{

    public class CategoryService : BaseService<Category>, ICategoryService
    {

        private readonly DbContextOptions<ProjectDbContext> _options;

        public CategoryService(DbContextOptions<ProjectDbContext> options)
        {
            _options = options;
        }

        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                using var context = new ProjectDbContext(_options);

                await context.Categories.AddAsync(category);

                await context.SaveChangesAsync().ConfigureAwait(false);

                return category;
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }

        public List<Category> ActiveCategories()
        {
            using var context = new ProjectDbContext(_options);

            List<Category> categories = new List<Category>();
            foreach (var category in context.Categories)
            {
                categories.Add(category);
            }
            return categories;
        }

        public Category GetByName(string name)
        {
            using var context = new ProjectDbContext(_options);

            Category category = context.Categories.Where(x => x.CategoryName == name).FirstOrDefault();

            return category;

        }
        
    }
}
