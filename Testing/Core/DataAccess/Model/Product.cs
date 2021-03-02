using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class Product:BaseEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Column(TypeName = "Money")]
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
