using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ClothingShop_prj.Models
{
    public class Color
    {
        public int ColorID { get; set; }
        [Required]
        public string Hue { get; set; }
        public virtual ICollection<Product> Products { get; set;}
    }
}