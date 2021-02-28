using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

    }
}
