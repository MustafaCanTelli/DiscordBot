using Core.Map;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Maps
{
   public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            Property(x => x.ProductName).IsRequired();
            Property(x => x.IccGold).IsRequired();  
        }
    }
}
