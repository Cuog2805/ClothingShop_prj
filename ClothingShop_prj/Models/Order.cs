using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Orderdate { get; set; } = DateTime.Now;
        //
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}