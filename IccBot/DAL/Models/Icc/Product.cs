using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Icc
{
   public class Product : Entity
    {
        public string Name { get; set; }
        public string Desciption { get; set; }
        public decimal Price { get; set; }

    }
}
