using Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core
{
    public class BaseEntity 
    {
        public BaseEntity()
        {
            Status = Status.Active;
        }

        public int? MasterID { get; set; }
        //[Column(TypeName = "decimal(18, 2)")]
        public ulong DiscordID { get; set; }
        //[Column(TypeName = "decimal(18, 2)")]
        public ulong ServerID { get; set; }
        public Status Status { get; set; }

    }
}
