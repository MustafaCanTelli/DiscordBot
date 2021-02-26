using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Status = Status.Active;
        }
        public Guid ID { get; set; }

        public int? MasterId { get; set; }

        public Status Status { get; set; }

        public int IccGold { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedAdUserName { get; set; }
        public string CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string UpdatedComputerName { get; set; }
        public string UpdatedIP { get; set; }
        public string UpdatedAdUserName { get; set; }
        public string UpdatedBy { get; set; }
    }
}
