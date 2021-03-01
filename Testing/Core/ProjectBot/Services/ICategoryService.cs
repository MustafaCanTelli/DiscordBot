using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBot.Services
{
    public interface ICategoryService
    {
        Task AddCategoryAsync(Category category);
        Task<Category> GetCategoryByNameAsync(string categoryName);

    }
}
