using Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BaseEntity : IEntity<Guid>
    {
        public Guid ID { get; set; }

        public BaseEntity()
        {
            Status = Status.Active;
        }

        public int? MasterID { get; set; }
        public ulong DiscordID { get; set; }
        public ulong ServerID { get; set; }
        public Status Status { get; set; }

    }
}
