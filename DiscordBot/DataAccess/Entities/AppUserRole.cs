using Core;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
   public class AppUserRole:BaseEntity
    {
        public UserRole Role { get; set; }
        public virtual List<AppUser> AppUsers { get; set; }
    }
}
