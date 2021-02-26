using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
   public class Category: BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        public List<SubCategory> SubCategories { get; set; }

    }
}
