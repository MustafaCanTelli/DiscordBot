using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core
{
   public interface IEntity<T>
    {
        [Key]
        T ID { get; set; }
    }
}
