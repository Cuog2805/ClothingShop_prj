using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Wishlist
    {
        public int WishlistID { get; set; }
        public string Description { get; set; }
        //
        public virtual ICollection<Product> Products { get; set; }
        public virtual Customer Customer { get; set; }
    }
}