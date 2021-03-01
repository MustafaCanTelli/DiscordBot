using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }

        [Column(TypeName = "Money")]
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

       
    }
}
