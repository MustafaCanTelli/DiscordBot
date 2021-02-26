using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Product: BaseEntity
    {
        public string ProductName { get; set; }       
        public string ImagePath { get; set; }

        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }

}
