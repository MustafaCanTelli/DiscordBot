using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Core.Map
{
   public class CoreMap<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        public CoreMap()
        {
            Property(x => x.CreatedDate).HasColumnType("datetime2");
            Property(x => x.UpdatedDate).HasColumnType("datetime2");
           
           
        }
    }
}
