using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class SubCategory:BaseEntity
    {
        public string SubCategoryName { get; set; }
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category GetCategory { get; set; }

        public virtual List<Product> Products { get; set; }

    }
}
