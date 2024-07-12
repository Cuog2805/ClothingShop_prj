using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Discount
    {
        public int DiscountID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
        public DateTime Expiry { get; set; } 
        public virtual ICollection<Customer> Customer { get; set; }
    }
}