using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBot.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ProjectDbContext _db;

        public CategoryService(ProjectDbContext db)
        {
            _db = db;
        }
        public async Task AddCategoryAsync(Category category)
        {
            await _db.Categories.AddAsync(category).ConfigureAwait(false);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<Category> GetCategoryByNameAsync(string categoryName)
        {
            throw new NotImplementedException();
        }
       
    }
}
