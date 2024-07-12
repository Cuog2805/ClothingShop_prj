using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class CartItem
    {
        public int CartItemID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Total { get; set; }
        //
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual History History { get; set; }
    }
}