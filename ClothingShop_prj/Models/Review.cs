using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Review
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Required]
        public int Rate { get; set; }
        //
        public virtual Product Products { get; set; }
        public virtual Customer Customers { get; set; }
    }
}