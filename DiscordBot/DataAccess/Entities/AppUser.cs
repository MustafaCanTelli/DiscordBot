using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
   public class AppUser:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ActivationId { get; set; }

        public int AppUserRoleId { get; set; }

        public bool IsActive { get; set; }

    }
}
