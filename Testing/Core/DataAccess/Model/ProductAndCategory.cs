using Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Model
{
    public class ProductAndCategory : BaseEntity
    {
        public Guid ProductID { get; set; }
        public Guid CategoryID { get; set; }


        [ForeignKey("ProductID")]
        public Product Product { get; set; }


        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

    }
}
