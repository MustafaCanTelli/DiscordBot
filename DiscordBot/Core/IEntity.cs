using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IEntity<T>
    {
         T ID { get; set; }

    }
}
