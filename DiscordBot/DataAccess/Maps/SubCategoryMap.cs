using Core.Map;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Maps
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            Property(x => x.SubCategoryName).IsRequired();
        }
    }
}
