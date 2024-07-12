using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Total { get; set; }
        //
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}