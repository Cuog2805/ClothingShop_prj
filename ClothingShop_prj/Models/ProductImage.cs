using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        [Required]
        public string Url { get; set; }
        public virtual Product Product { get; set; } 
    }
}