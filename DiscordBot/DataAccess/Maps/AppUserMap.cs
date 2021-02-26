using Core.Map;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Maps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            Property(x => x.UserName).IsRequired().HasMaxLength(50);
            Property(x => x.Password).IsRequired().HasMaxLength(155);
            Property(x => x.Email).IsRequired().HasMaxLength(155);
        }
    }
}
