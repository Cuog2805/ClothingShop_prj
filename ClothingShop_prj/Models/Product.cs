using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public float PriceDecreased { get; set; }
        [Required]
        public string Avatar { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Rate { get; set; } = 0;
        public DateTime Published { get; set; } = DateTime.Now;
        //navigation property
        public virtual ICollection<Size> Sizes { get; set; }
        public virtual ICollection<Color> Colors { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<CategoryItem> CategoryItems { get; set; }
        public virtual ICollection<Type> Types { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<AdminProduct> AdminProducts { get; set; }
    }
}