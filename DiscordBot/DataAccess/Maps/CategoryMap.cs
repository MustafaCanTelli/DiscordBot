using Core.Map;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Maps
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            Property(x => x.CategoryName).IsRequired();
        }
    }
}
