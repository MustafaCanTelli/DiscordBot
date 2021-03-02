using DataAccess.Model;
using DSharpPlus.CommandsNext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface ICategoryService
    {
        Task<Category> AddCategory(Category category);

        Category GetByName(string name);

        List<Category> ActiveCategories();
    }
}
